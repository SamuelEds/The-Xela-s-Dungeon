using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaFall : MonoBehaviour
{
    private Animator animator;

   
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player"){
            animator.SetBool("ativar",true);
        }
    }

    void SumirBloco(){
        Destroy(this.gameObject);
        Debug.Log("SUMIU");
    }
}
