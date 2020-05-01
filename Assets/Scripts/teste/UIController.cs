using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject panelPause;
    public GameObject ButtonPause;

    void Start()
    {
        panelPause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowPause(){
        panelPause.SetActive(true);
        ButtonPause.SetActive(false);
        Time.timeScale = 0;
        Debug.Log(Time.timeScale);
    }

    public void ResumeGame(){
        panelPause.SetActive(false);
        ButtonPause.SetActive(true);
        Time.timeScale = 1;
        Debug.Log(Time.timeScale);
    }

    public void ExitGame(){
        Application.Quit();
    }
}
