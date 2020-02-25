using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
	public string cenaSave;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("save",cenaSave);
    }
}
