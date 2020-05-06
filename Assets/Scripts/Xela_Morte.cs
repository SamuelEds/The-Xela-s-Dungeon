using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Xela_Morte : MonoBehaviour
{
   public enum TipoMorte {MortePorBuraco, MortePorEspinho};
    public TipoMorte      Morte;
    [Header("Tempo de FadeOut")]
    public int  TempoDeFadeout = 1;
    public Animator MorteFadeOut;
    public GameObject DesativarPlayer;
    [Space(20)]
    [Header("Corpo do Xela")]
    public Rigidbody2D corpoXela;
    

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
                    DesativarPlayer.GetComponent<PlayerCtrl>().enabled = false;
                    corpoXela.constraints = RigidbodyConstraints2D.FreezePositionX;
                    StartCoroutine("MortePorBuraco");
                break; 

                case TipoMorte.MortePorEspinho:
                    MorteFadeOut.SetBool("MorreuEspinhos",true);
                    corpoXela.constraints = RigidbodyConstraints2D.FreezePositionX;
                    Destroy(this.gameObject);
                break;
            }
        }else if(col.gameObject.tag == "espinhos"){
            MorteFadeOut.SetBool("MorreuEspinhos",true);
                    
            Destroy(this.gameObject);
        }
    }
}
