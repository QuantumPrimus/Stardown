using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderSound : MonoBehaviour {
	public AudioClip clip;

	private Slider slider;
	private AudioSource source;
	private int sliderVal;
	private int lastVal = 100;
	private float timer;
	void Start () {
		source = GameObject.FindGameObjectWithTag("Audio Source").GetComponent<AudioSource>();
		slider = GetComponent<Slider>();
		// sliderVal = Mathf.RoundToInt(slider.value * 100);
		slider.value = PlayerPrefs.MusicVol;
	}
	
	void Update () {
		sliderVal = Mathf.RoundToInt(slider.value * 100);
		int dif = sliderVal - lastVal;
		// Debug.Log(dif);
		timer += Time.deltaTime;
		if(dif <= -1 && timer >= .126f || dif >= 1 && timer >= .126f)
		{
			timer = 0;
			//source.Stop();
			source.PlayOneShot(clip, Random.Range(.5f, 1f));
		}

		lastVal = sliderVal;
		PlayerPrefs.MusicVol = slider.value;
	}
}
