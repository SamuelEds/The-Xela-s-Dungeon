using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject AtivarPlayer;

	[Header("Controle de Cenas")]
	public string ProximaCenaDepoisDoLoading;
	public string CenaDeLoading;

    void Start()
    {
        AtivarPlayer.SetActive(true);

        /*if (CenaDeLoading == "")
        {
            SceneManager.LoadScene(ProximaCenaDepoisDoLoading);
        }
        else
        {
            PlayerPrefs.SetString("proxima_cena", ProximaCenaDepoisDoLoading); //Vai declarar a cena na tela de Loading
            SceneManager.LoadScene(CenaDeLoading);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        //Quando o jogador apertar ESC do teclado
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Screen.fullScreen = !Screen.fullScreen;

        }

    }
}
