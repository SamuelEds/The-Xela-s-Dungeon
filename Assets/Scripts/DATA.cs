using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DATA : MonoBehaviour
{
	private GameObject[] datas;

	void Awake(){ //Executada antes de todos os Scripts
    	datas = GameObject.FindGameObjectsWithTag("data");

    	if(datas.Length >= 2){
    		Destroy(datas[0]);
    	}

    	DontDestroyOnLoad(transform.gameObject);
    }
}
