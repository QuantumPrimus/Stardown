//Fullfills Implentation 4
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefs : MonoBehaviour {
	private static float musicVol, soundVol;
	void Awake()
	{
		DontDestroyOnLoad(gameObject);

		if (FindObjectsOfType(GetType()).Length > 1)
			Destroy(gameObject);
	}

	public static float MusicVol
	{
		get	{ return musicVol; }

		set { musicVol = value; }
	}

	public static float SoundVol
	{
		get	{ return soundVol; }
		set { soundVol = value;	}
	}

}
