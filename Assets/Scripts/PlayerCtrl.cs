using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{
	[Header("Variáveis de movimento")]
	public  float 		HorizontalAxis;
	private Rigidbody2D playerRB;
	public  float 		speed;
	private Animator    anim;
	public  float		speedY;
	public  bool 		lookLeft;
	private Transform   playerTransform;
	public 	float 		speedX;

	[Header("Variáveis de Pulo")]
	public 	bool 		groundCheck;
	public 	Transform 	groundCheckPosition;
	public 	float 	 	groundCheckRaio = 0.2f;
	public 	LayerMask  	isGround;
	public 	float 	 	forcaPulo;
	public  bool 		pulou;

	[Header("Variáveis que faz o Player puxar")]
	public 	float 		distance = 1f;
	public 	LayerMask 	boxMask;
	private GameObject 	box;
	public  float 		noQuick;
	private bool        puxando;
	public  Rigidbody2D caixa;

	[Header("Controle de Cenas")]
	public string ProximaCena;

	[Header("Controle de áudios")]
	public 	AudioClip 	clipPulando;
	private AudioSource audio;
	public  AudioClip 	footSteps;
	public  AudioClip  	Draging;

	[Header("Áudio para movimentação da caixa")]
	public	AudioClip 	arrastando;

	void Start()
	{
		playerRB = GetComponent<Rigidbody2D>();   
		anim = GetComponent<Animator>(); 
		playerTransform = GetComponent<Transform>();
		audio = GetComponent<AudioSource>();
		pulou = true;

		if(caixa != null){
			caixa.constraints = RigidbodyConstraints2D.FreezeRotation;
			caixa.constraints = ~RigidbodyConstraints2D.FreezePositionY;
		}
		
	}

	void FixedUpdate(){

		speedX = playerRB.velocity.x;

		HorizontalAxis = Input.GetAxisRaw("Horizontal");
		
		groundCheck = Physics2D.OverlapCircle(groundCheckPosition.position,groundCheckRaio,isGround);

		Physics2D.queriesStartInColliders = false;
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance,boxMask);

		if(groundCheck){



			if(hit.collider != null && Input.GetKeyDown(KeyCode.B) && hit.collider.gameObject.tag == "MoveObject"){

			//Fazer o Player não quicar
				forcaPulo = noQuick;

				anim.SetBool("puxando",true);
				anim.SetBool("correndo",false);

				puxando = true;

				anim.SetBool("terminouDePuxar",true);


				pulou = false;

				caixa.constraints = RigidbodyConstraints2D.None;
				caixa.constraints = RigidbodyConstraints2D.FreezeRotation;

				box = hit.collider.gameObject;
				box.GetComponent<FixedJoint2D>().enabled = true;
				box.GetComponent<boxpull> ().beingPushed = true;
				box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();


			}else if(Input.GetKeyUp(KeyCode.B)){

				caixa.constraints = ~RigidbodyConstraints2D.FreezePositionY;

				box.GetComponent<FixedJoint2D>().enabled = false;
				box.GetComponent<boxpull> ().beingPushed = false;
				forcaPulo = 440000f;


				anim.SetBool("terminouDePuxar",false);
				anim.SetBool("puxando",false);

				anim.SetBool("correndo",true);


				puxando = false;
				pulou = true;

			}
		}

		
		
		
	}

    // Update is called once per frame
	void Update()
	{
		if((puxando && speedX > 0) || (puxando && speedX < 0)){

			
			anim.SetInteger("andando_e_puxando", (int) speedX);

		}else if(puxando && speedX == 0){

			anim.SetInteger("andando_e_puxando", 0);
			anim.SetBool("puxando",true);

		}else if(!puxando){

			anim.SetInteger("andando_e_puxando", 0);

		}else if(!puxando && speedX != 0){
			anim.SetInteger("andando_e_puxando", 0);
			anim.SetBool("puxando",false);
		}

		speedY = playerRB.velocity.y;
		
		playerRB.velocity = new Vector2(HorizontalAxis * speed, speedY);   

		if(HorizontalAxis > 0 || HorizontalAxis < 0 && !puxando){
			anim.SetBool("correndo",true);
		}else{
			anim.SetBool("correndo",false);
		}

		

		if(HorizontalAxis > 0 && lookLeft){
			virar();
		}else if(HorizontalAxis < 0  && !lookLeft){
			virar();
		}

		if(Input.GetButtonDown("Jump") && groundCheck){
			playerRB.AddForce(new Vector2(0,forcaPulo));
			if(pulou){
				PlaySoundEffect();	
			}
			
		}

		if(groundCheck){
			anim.SetBool("pulou",false);
			anim.SetInteger("pulo",(int) 0f);
		}else{
			anim.SetBool("pulou",true);
		}

		if(Input.GetKeyDown(KeyCode.G)){
			SceneManager.LoadScene("Menu");
		}

		anim.SetInteger("pulo",(int) speedY);

	}

	void virar(){
		if(!puxando){
			lookLeft = !lookLeft;

			Vector2 virado = new Vector2(playerTransform.localScale.x * -1,playerTransform.localScale.y);

			playerTransform.localScale = virado;	
		}
	}

	void OnTriggerEnter2D(Collider2D col){ //Quando o Player chegar a Porta
		if(col.gameObject.tag == "saida"){
			SceneManager.LoadScene(ProximaCena);
			}else if(col.gameObject.tag == "morte"){
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}

		void PlaySoundEffect(){
			audio.clip = clipPulando;
			audio.Play();
		}

		void footStep(){
			if(groundCheck){

				audio.clip = footSteps;
				audio.Play();
			}
		}

	void PlayDrag(){ //Chamar na animacão de andando com a caixa
		audio.clip = Draging;
		audio.Play();
	}

	void PlayArrastando(){
		audio.clip = arrastando;
		audio.Play();
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "MovingPlataform"){
			playerTransform.parent = col.transform;
		}
	}

	void OnCollisionExit2D(Collision2D col){
		if(col.gameObject.tag == "MovingPlataform"){
			playerTransform.parent = null;
		}
	}
}
