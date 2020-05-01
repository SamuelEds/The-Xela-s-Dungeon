using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using TMPro;
public class Pause : MonoBehaviour
{

    [Header("Telas de Pause")]
    public GameObject PainelPause;

    [Space(20)]
    [Header("Configurações de Volume")]
    public Slider BarraVolume;
    public float Volume;
    public Text PorcentagemVolume;
    [Space(20)]
    [Header("Configurações de Qualidade")]
    public Dropdown Qualidades;
    private int     qualidadeGrafica;
    //public  Font    FontTextoDropdown;
    //public  TextMeshProUGUI  Output;

    void Start()
    {
        //============SETAR PAINÉIS============\\
        PainelPause.SetActive(false);
        Time.timeScale = 1;

        //============SETAR VOLUME AO INICIAR A CENA============\\
        if (PlayerPrefs.HasKey("Volume"))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("Volume");
            BarraVolume.value = PlayerPrefs.GetFloat("Volume");


        }
        else
        {
            PlayerPrefs.SetFloat("Volume", 1);
            BarraVolume.value = 1;
        }

        BarraVolume.maxValue = 1;
        BarraVolume.minValue = 0;

        //PorcentagemVolume.text = BarraVolume.value + "%";

        //AudioListener.volume = 1;

        //==================CONFIGURAÇÒES DE QUALIDADES==================\\
        //AjustarQualidades();

        /*if (PlayerPrefs.HasKey("Graficos"))
        {
            qualidadeGrafica = PlayerPrefs.GetInt("Graficos");
            QualitySettings.SetQualityLevel(qualidadeGrafica);
            Qualidades.value = qualidadeGrafica;
        }
        else
        {
            QualitySettings.SetQualityLevel((QualitySettings.names.Length - 1));
            qualidadeGrafica = (QualitySettings.names.Length - 1);
            PlayerPrefs.SetInt("Graficos", qualidadeGrafica);
            Qualidades.value = qualidadeGrafica;
        }*/

        if(PlayerPrefs.HasKey("Graficos")){
            qualidadeGrafica = PlayerPrefs.GetInt("Graficos");
            Qualidades.value = qualidadeGrafica;
        }else{
            Qualidades.value = 3;
            PlayerPrefs.SetInt("Graficos",3);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {

            if (Time.timeScale == 1)
            {
                PainelPause.SetActive(true);
                Time.timeScale = 0;
                AudioListener.pause = true;

            }
            else
            {
                ResumeGame();
            }
        }


        //============SETAR O VOLUME AO DECORRER DA CENA============\\
        PlayerPrefs.SetFloat("Volume", BarraVolume.value);

        if (PlayerPrefs.HasKey("Volume"))
        {
            Volume = PlayerPrefs.GetFloat("Volume");
            BarraVolume.value = Volume;
            AudioListener.volume = Volume;
        }
        else
        {
            PlayerPrefs.SetFloat("Volume", 1);
            BarraVolume.value = 1;
            AudioListener.volume = 1;
        }

        //=====================SETAR QUALIDADE AO DECORRER DA CENA=====================\\
        PlayerPrefs.SetInt ("Graficos", Qualidades.value);
        //QualitySettings.SetQualityLevel(PlayerPrefs.GetInt ("Graficos"));
    }

    void FixedUpdate()
    {
        if(PlayerPrefs.GetInt("Graficos") == 0){
            //Debug.Log("Nível de qualidade Fantástica");
            QualitySettings.SetQualityLevel(5);
            
        }

        if(PlayerPrefs.GetInt("Graficos") == 1){
            //Debug.Log("Nível de qualidade Simples");
            QualitySettings.SetQualityLevel(2);
        }

        if(PlayerPrefs.GetInt("Graficos") == 2){
            //Debug.Log("Nível de qualidade Baixo");
            QualitySettings.SetQualityLevel(0);
        }
    }

    public void ResumeGame()
    {
        PainelPause.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

    public void VoltarMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PorcentagemDoVolume(float valor)
    {
        PorcentagemVolume.text = Mathf.RoundToInt(valor * 100) + "%";
    }

    /*private void AjustarQualidades(){
      string[] nomes = QualitySettings.names;
      Qualidades.options.Clear ();
      for(int y = 0; y < 3; y++){
        Qualidades.options.Add(new Dropdown.OptionData() { text = nomes[y] });
        Qualidades.captionText.font = FontTextoDropdown;
      }
      Qualidades.captionText.text = "Qualidade";



   }*/

   /*public void HandleInputData(int val){
       if(val == 0){
           Debug.Log("Qualidade Gráfica nível 1");
       }

       if(val == 1){
           Debug.Log("Qualidade Gráfica nível 2");
       }

       if(val == 2){
           Debug.Log("Qualidade Gráfica nível 3");
       }
   }*/

}
