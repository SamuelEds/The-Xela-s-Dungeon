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
	private float		speedY;
	public  bool 		lookLeft;
	private  Transform   playerTransform;

	[Header("Variáveis de Pulo")]
	public 	bool 		groundCheck;
	public 	Transform 	groundCheckPosition;
	public 	float 	 	groundCheckRaio = 0.2f;
	public 	LayerMask  	isGround;
	public 	float 	 	forcaPulo;

	[Header("Variáveis dque faz o Player puxar")]
	public float distance = 1f;
	public 	LayerMask 	boxMask;
	private GameObject 	box;
	public  float 		noQuick;
	private bool        puxando;

	[Header("Controle de Cenas")]
	public string ProximaCena;

	[Header("Controle de áudios")]
	public 	AudioClip clipPulando;
	private AudioSource audio;
	public  AudioClip footSteps;
	public  AudioClip  Draging;

	void Start()
	{
		playerRB = GetComponent<Rigidbody2D>();   
		anim = GetComponent<Animator>(); 
		playerTransform = GetComponent<Transform>();
		audio = GetComponent<AudioSource>();
	}

	void FixedUpdate(){
		HorizontalAxis = Input.GetAxisRaw("Horizontal");
		groundCheck = Physics2D.OverlapCircle(groundCheckPosition.position,groundCheckRaio,isGround);

		Physics2D.queriesStartInColliders = false;
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance,boxMask);

		if(hit.collider != null && Input.GetKeyDown(KeyCode.B) && hit.collider.gameObject.tag == "MoveObject"){
			
			playerRB.velocity = new Vector2(HorizontalAxis * speed, speedY * 0); 
			//Fazer o Player não quicar
			forcaPulo = noQuick;

			anim.SetBool("puxando",true);
			anim.SetBool("correndo",false);

			box = hit.collider.gameObject;
			box.GetComponent<FixedJoint2D>().enabled = true;
			box.GetComponent<boxpull> ().beingPushed = true;
			box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();

			
			puxando = true;
		}else if(Input.GetKeyUp(KeyCode.B)){

			box.GetComponent<FixedJoint2D>().enabled = false;
			box.GetComponent<boxpull> ().beingPushed = false;
			forcaPulo = 100000f;
			anim.SetBool("puxando",false);
			anim.SetBool("correndo",true);

			puxando = false;
			
		}

	}

    // Update is called once per frame
	void Update()
	{
		speedY = playerRB.velocity.y;
		playerRB.velocity = new Vector2(HorizontalAxis * speed, speedY);   

		if(HorizontalAxis > 0 || HorizontalAxis < 0){
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
			PlaySoundEffect();
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
		}
	}

	void PlaySoundEffect(){
		audio.clip = clipPulando;
		audio.Play();
	}

	void footStep(){
		audio.clip = footSteps;
		audio.Play();
	}

	void PlayDrag(){ //Chamar na animacão de andando com a caixa
		audio.clip = Draging;
		audio.Play();
	}
}
