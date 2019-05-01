using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour {

    static private bool isPlayerAlive = true;

	void Start () {
		
	}
	
	void Update () {
        if (!isPlayerAlive)
        {
            Debug.Log("Checking");
            Debug.Log(Input.GetKeyDown(KeyCode.R));
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene(1);
        }
	}

    static public void setAliveState(bool a)
    {
        // Debug.Log(a);
        isPlayerAlive = a;
    }
}
