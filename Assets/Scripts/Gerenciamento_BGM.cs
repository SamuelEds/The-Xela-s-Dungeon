using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gerenciamento_BGM : MonoBehaviour
{
    public GameObject NotDestroy;
    public GameObject SomFundo;
    // Start is called before the first frame update
    void Start()
    {
        
        DontDestroyOnLoad(NotDestroy);

        /*if(SceneManager.GetActiveScene().name == "LOADING_INICIAL" || SceneManager.GetActiveScene().name == "Loading_cena_a_cena" || SceneManager.GetActiveScene().name == "intro"){
            SomFundo.GetComponent<AudioSource>().Pause();
            Debug.Log("Pausar");
        }else{
            SomFundo.GetComponent<AudioSource>().UnPause();
            Debug.Log("Despausar");
        }*/   

        
    }
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "LOADING_INICIAL" || SceneManager.GetActiveScene().name == "Loading_cena_a_cena" || SceneManager.GetActiveScene().name == "intro"){
            SomFundo.GetComponent<AudioSource>().Pause();
            //Debug.Log("Pausar");
        }else{
            SomFundo.GetComponent<AudioSource>().UnPause();
            //Debug.Log("Despausar");
        }  
    }
}
