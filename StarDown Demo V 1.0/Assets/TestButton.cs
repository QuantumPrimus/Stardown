using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestButton : MonoBehaviour {
    public int scene;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void click()
    {
        
        if(scene == -1)
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
			Application.Quit();
            #endif
        }
        else
        {
            SceneManager.LoadScene(scene);
        }
    }
}
