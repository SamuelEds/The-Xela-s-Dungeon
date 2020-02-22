using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxpull : MonoBehaviour
{
	public 	bool 		beingPushed;
	private float 		xPosition;
	public  int 		mode;
	public 	float 		imovableMass;
	public 	float 		defaultMass;
	private Rigidbody2D boxBody;
	private Transform   boxTransform;

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
		if(mode == 0){

			if(!beingPushed){
				
				boxBody.mass = imovableMass;
			}else{
				xPosition = transform.position.x;
				boxBody.mass = defaultMass;
			}	

		}
	}
}
