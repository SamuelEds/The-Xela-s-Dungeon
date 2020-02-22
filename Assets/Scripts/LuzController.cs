using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzController : MonoBehaviour
{
    
	public Light luz;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Enfraquecer(){
    	luz.intensity = 2.22f;
    }

    void Fortalecer(){
    	luz.intensity = 3.20f;
    }
}
