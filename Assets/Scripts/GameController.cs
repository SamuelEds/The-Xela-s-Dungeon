using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
	void Start()
	{

	}

    // Update is called once per frame
	void Update()
	{
		//Quando o jogador apertar ESC do teclado
		if(Input.GetKeyDown(KeyCode.Escape)){ 
			Screen.fullScreen =! Screen.fullScreen; 

		}

	}
}
