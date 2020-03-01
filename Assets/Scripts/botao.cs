using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botao : MonoBehaviour
{
	[Header("Controle de Plataformas")]
	public  Animator plat;
	private Animator anim;

	void Start(){
		anim = GetComponent<Animator>();
	}

    void OnTriggerEnter2D(Collider2D col){
    	if(col.gameObject.tag == "MoveObject"){
    		anim.SetBool("ativarButao",true);
    		plat.SetBool("ativar",true);
    	}
    }

    void OnTriggerExit2D(){
    	anim.SetBool("ativarButao",false);
    	plat.SetBool("ativar",false);
    }
}
