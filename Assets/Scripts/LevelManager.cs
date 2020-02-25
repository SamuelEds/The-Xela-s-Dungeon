using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject btn_continuar;

    void Update(){
        if(PlayerPrefs.HasKey("save")){ //Verificar se o Player adentrou alguma fase
            btn_continuar.SetActive(true);
        }else{
            btn_continuar.SetActive(false);
        }
    }

    void OnGUI()
    {
        //Delete all of the PlayerPrefs settings by pressing this Button
        if (GUI.Button(new Rect(100, 200, 200, 60), "Delete")) //Vai fazer um botão na tela para deletar todos os saves
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void LoadScene(string scene){
    	SceneManager.LoadScene(scene);
    }

    public void SairJogo(){
    	Application.Quit();
    }

    public void Continuar(){
    	if(PlayerPrefs.HasKey("save")){ //Verifica se há algum save
            string save = PlayerPrefs.GetString("save");
            SceneManager.LoadScene(save);
        }else{
        }
    }

}
