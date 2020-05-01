using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class espinhos : MonoBehaviour
{
    public float  TempoMorteEspinho = 0.2f;
    [Space(20)]
    [Header("Controle de som")]
    public AudioSource audioEspinho;
    public  AudioClip   clipeEspinho;

    IEnumerator MORTE_ESPINHO(){
        yield return new WaitForSeconds(TempoMorteEspinho);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            audioEspinho.clip = clipeEspinho;
            audioEspinho.Play();
            StartCoroutine("MORTE_ESPINHO");
        }
    }
}
