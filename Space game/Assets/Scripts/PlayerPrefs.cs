//Fullfills Implentation 4
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefs : MonoBehaviour {
	private static float musicVol;
	void Awake()
	{
		DontDestroyOnLoad(gameObject);	
	}

	public static float MusicVol
	{
		get
		{
			return musicVol;
		}
		set
		{
			musicVol = value;
		}
	}


}
