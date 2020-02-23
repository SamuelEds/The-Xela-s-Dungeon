using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	[Header("Variáveis para Pausar o jogo")]
	public GameObject panelPause;
	bool isPause;
	public static bool GamePausado = false;

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

		if(Input.GetKeyDown(KeyCode.P)){

			if(GamePausado){
				UnPause();
			}else{
				Pause();
			}

		}

		

	}

	//Pausar o jogo
	void Pause(){
		Time.timeScale = 0;
		GamePausado = true;
		panelPause.SetActive(true);
	}

	//Despausar o jogo
	void UnPause(){
		Time.timeScale = 1;
		GamePausado = false;
		panelPause.SetActive(false);
	}
}
