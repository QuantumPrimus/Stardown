using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour {
    private static Text txt;


	void Start () {
        txt = GetComponent<Text>();
	}
	
	void Update () {
	}

    
    public static void updateScore<T>(T value)
    {
        string nValue = value.ToString();
        txt.text = nValue;
    }
}
