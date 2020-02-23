using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
	public GameObject gb;
	void Start(){

	}

	void sair(){
		gb.SetActive(false);
	}
}
