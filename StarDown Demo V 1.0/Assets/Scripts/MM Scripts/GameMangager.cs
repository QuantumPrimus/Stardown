//Is able to fullfill implement 3
//Just fuck this thing probably
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMangager : MonoBehaviour {
	public bool Music;
	public bool soundFX;
	public AudioClip clip;
	public float musicLevel;
	public float fadeValue;
	private AudioSource source;	

	void Start () {
		source = GameObject.FindGameObjectWithTag("Music Source").GetComponent<AudioSource>();
		source.loop = true;
		source.PlayOneShot(clip,.1f);
		PlayerPrefs.MusicVol = musicLevel;
		// StartCoroutine(fadeMusic());
	}
	
	void Update () {
		fadeIn();
	}

	private void OnLevelWasLoaded(int level)
	{
		musicLevel = PlayerPrefs.MusicVol;
	}
	void fadeIn()
	{
		if (source.volume < musicLevel)
		{
			source.volume += fadeValue * Time.deltaTime;
		}
	}
}
