using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
	[Header("Variáveis para Pausar o jogo")]
	public GameObject panelPause;
	public static bool GamePausado = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){

			if(GamePausado){
				Resume();
			}else{
				Pause();
			}

		}
	}

	//Pausar o jogo
	void Pause(){
		panelPause.SetActive(true);
		Time.timeScale = 0f;
		GamePausado = true;
	}

	//Despausar o jogo
	void Resume(){
		panelPause.SetActive(false);
		Time.timeScale = 1f;
		GamePausado = false;
	}
}
