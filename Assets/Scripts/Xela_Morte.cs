using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Xela_Morte : MonoBehaviour
{
    public enum TipoMorte {MortePorBuraco, MortePorEspinho};
    public TipoMorte      Morte;
    [Header("Tempo de FadeOut")]
    public int  TempoDeFadeout;
    public Animator MorteFadeOut;
    public GameObject DesativarPlayer;
    

    IEnumerator MortePorBuraco(){
        
        yield return new WaitForSeconds(TempoDeFadeout);
        //Debug.Log("Espereou "+TempoDeFadeout+" de Secundos para o Fadeout");
        MorteFadeOut.SetBool("morreu",true);
        DesativarPlayer.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "morte"){
            switch(Morte){
                case TipoMorte.MortePorBuraco:
                    StartCoroutine("MortePorBuraco");
                break; 

                case TipoMorte.MortePorEspinho:
                    MorteFadeOut.SetBool("MorreuEspinhos",true);
                    
                    Destroy(this.gameObject);
                break;
            }
        }else if(col.gameObject.tag == "espinhos"){
            MorteFadeOut.SetBool("MorreuEspinhos",true);
                    
            Destroy(this.gameObject);
        }
    }
}
