using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btn_Controller : MonoBehaviour
{
	[Header("Controle de sons")]
	public  AudioClip clipClick;
	private AudioSource audio;

	void Start(){
		audio = GetComponent<AudioSource>();
	}
    void PlayClick(){
    	audio.clip = clipClick;
    	audio.Play();
    }
}
