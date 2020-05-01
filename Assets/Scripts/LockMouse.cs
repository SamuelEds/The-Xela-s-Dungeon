using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMouse : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 1){
            //Cursor.visible = false;
        }else{
            //Cursor.visible = true;
        }

    }
}
