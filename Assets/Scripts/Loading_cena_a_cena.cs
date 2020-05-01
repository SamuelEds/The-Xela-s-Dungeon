using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading_cena_a_cena : MonoBehaviour
{
    [Header("Nome da cena")]
    public string CenaACarregar;
    [Space(20)]
    public Texture texturaFUNDO;
    public string  textoLoading = "Carregando...";
    public Color   corDoTexto = Color.white;
    public Font    FontDoTexto;
    [Space(20)]
    [Range(0.5f, 3.0f)]
    public float   tamanhoDoTexto = 1.5f;
    [Range(-8f,4f)]
    public float   deslocarTextoX = 2;
    [Range(-4.5f,4.5f)]
    public float   deslocarTextoY = 3;
    private bool mostrarCarregamento = false;
    private int progresso = 0;

    void Start(){
        if(PlayerPrefs.HasKey("proxima_cena")){
            string ProximaCena = PlayerPrefs.GetString("proxima_cena");
            StartCoroutine(CenaDeCarregamento(ProximaCena));
        }else{
            StartCoroutine(CenaDeCarregamento(CenaACarregar));
        }
        
        
    }

    IEnumerator CenaDeCarregamento(string cena){
        mostrarCarregamento = true;
        AsyncOperation carregamento = SceneManager.LoadSceneAsync(cena);

        while(!carregamento.isDone){
            progresso = (int) (carregamento.progress * 100);
            yield return null;
        }
    }

    void OnGUI(){
        if(mostrarCarregamento){
            //CONFIGURÇÕES DE TEXTO
            GUI.contentColor = corDoTexto;
            GUI.skin.font = FontDoTexto;
            GUI.skin.label.fontSize = (int) (Screen.height / 50 * tamanhoDoTexto);

            //COMFIGURAÇÕES DE TEXTURA
            GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),texturaFUNDO);

            //TEXTO
            float deslocXTexto = (Screen.height / 10) * deslocarTextoX;
            float deslocYTexto = (Screen.height / 10) * deslocarTextoY;
            GUI.Label(new Rect(Screen.width / 2 + deslocXTexto, Screen.height / 2 + deslocYTexto, Screen.width, Screen.height), textoLoading + " "+progresso+"%");

        }
    }
}
