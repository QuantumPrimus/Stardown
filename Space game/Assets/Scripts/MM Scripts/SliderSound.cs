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
		Debug.Log(name);
		source = GameObject.FindGameObjectWithTag("Sound FX Source").GetComponent<AudioSource>();
		slider = GetComponent<Slider>();
		// sliderVal = Mathf.RoundToInt(slider.value * 100);
		slider.value = PlayerPrefs.MusicVol;
	}
	
	void Update () {
		sliderVal = Mathf.RoundToInt(slider.value * 100);
		int dif = sliderVal - lastVal;
		// Debug.Log(dif);
		timer += Time.deltaTime;
		if(dif <= -1 && timer >=  clip.length|| dif >= 1 && timer >= clip.length)
		{
			timer = 0;
			//source.Stop();
			source.PlayOneShot(clip, Random.Range(.5f, 1f));
		}

		lastVal = sliderVal;
		//Going to change this to be be set when pressing a backbutton
		//which will autosave all the values from the scene.
		// PlayerPrefs.MusicVol = slider.value;
	}
}
