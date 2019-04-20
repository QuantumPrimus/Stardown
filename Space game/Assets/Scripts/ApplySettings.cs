using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ApplySettings : MonoBehaviour
{

	private Slider musicSlider;
	private Slider soundFXSlider;
	private AudioSource musicSource;
	private AudioSource fxSource;
	void Start()
	{
		musicSlider = GameObject.FindGameObjectWithTag("Music Slider").GetComponentInChildren<Slider>();
		soundFXSlider = GameObject.FindGameObjectWithTag("Sound FX Slider").GetComponentInChildren<Slider>();
		musicSource = GameObject.FindGameObjectWithTag("Music Source").GetComponent<AudioSource>();
		fxSource = GameObject.FindGameObjectWithTag("Sound FX Source").GetComponent<AudioSource>();
	}

	private void OnMouseDown()
	{
		PlayerPrefs.MusicVol = musicSlider.value;
		PlayerPrefs.SoundVol = soundFXSlider.value;
		fxSource.volume = PlayerPrefs.SoundVol;
		musicSource.volume = PlayerPrefs.MusicVol;
	}

}
