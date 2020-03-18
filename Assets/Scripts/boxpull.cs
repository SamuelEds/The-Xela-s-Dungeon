using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxpull : MonoBehaviour
{
	[Header("Verificar se está sendo puxado")]
	public 	bool 		beingPushed;

	[Header("Pesgar a posição inicial da caixa")]
	private float 		xPosition;

	[Header("Mudar a massa da caixa")]
	public 	float 		imovableMass;
	public 	float 		defaultMass;
	private Rigidbody2D boxBody;

	[Header("Pegar a movimentação da caixa")]
	private Transform   boxTransform;
	public  float 		speedX;

    // Start is called before the first frame update
	void Start()
	{
		xPosition = transform.position.x;
		boxBody = GetComponent<Rigidbody2D>();
		boxTransform = GetComponent<Transform>();
	}

    // Update is called once per frame
	void FixedUpdate()
	{

		if(!beingPushed){

			boxBody.mass = imovableMass;
		}else{
			xPosition = transform.position.x;
			boxBody.mass = defaultMass;
			speedX = boxBody.velocity.x;
		}	

		
	}
}
