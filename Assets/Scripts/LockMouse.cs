using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockMouse : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Menu"){
            Cursor.visible = true;
        }else if(Time.timeScale == 1){
            Cursor.visible = false;
        }else{
            Cursor.visible = true;
        }

    }
}
