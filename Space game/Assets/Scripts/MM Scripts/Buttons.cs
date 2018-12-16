using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour {

	public int scene; 


	public void click()
	{
		SceneManager.LoadScene(scene);
	}
}
