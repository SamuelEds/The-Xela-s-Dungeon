using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    void OnGUI(){
    	const int buttonWidht = 84;
    	const int buttonHeight = 60;

    	if(GUI.Button(new Rect(Screen.width / 2 - (buttonWidht / 2), (2 * Screen.height / 3) - (buttonHeight / 2), buttonWidht , buttonHeight), "JOGAR!")){
    		Application.LoadLevel("Cena01");
    	}
    }
}
