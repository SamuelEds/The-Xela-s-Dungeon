using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{

	[Header("Obter o Animators dos Objetos")]
	public Animator alavanca;
	public Animator Plataforma1;
	public Animator Plataforma2;

	[Header("Verificar se o Player tocou na alavanca novamente")]
	public bool Tocou;

	void OnTriggerEnter2D(Collider2D col){
		if(!Tocou){
			if(col.gameObject.tag == "alavanca"){
				alavanca.SetBool("clicado",true);
				Plataforma1.SetBool("ativar",true);
				Plataforma2.SetBool("ativar2",true);
				Tocou = true;
			}
		}else{
			alavanca.SetBool("clicado",false);
			Plataforma1.SetBool("ativar",false);
			Plataforma2.SetBool("ativar2",false);
			Tocou = false;
		}

	}
}
