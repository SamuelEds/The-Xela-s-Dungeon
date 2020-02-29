using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col){
    	if(col.gameObject.tag == "Player"){
    		col.transform.parent = transform;
    	}
    }

    void OnTriggerExit2D(Collider2D col){
    	if(col.gameObject.tag == "Player"){
    		col.transform.parent = null;
    	}
    }
}
