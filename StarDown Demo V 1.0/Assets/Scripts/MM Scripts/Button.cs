//Custom Button script
//Is able to replace the "Hover sound" script and is an easy (bug long) fix for Bug 1.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {
	public AudioClip clip;
	public Color normalColor;
	public Color highlighedColor;
	public Color pressedColor;
	public int scene;
	public float fadeTime;
	public bool isExit;

	private Text txt;
	private AudioSource source;
	private Image img;

	void Start () {
		// source = GameObject.FindGameObjectWithTag("Sound FX Source").GetComponent<AudioSource>();
		img = GetComponent<Image>();
		Debug.Log(img);
		Debug.Log(img);
		if (img == null)
		{
            Debug.Log("I dont know what to do anymore");
			txt = GetComponent<Text>();
			txt.color = normalColor;
		}
		else
			img.color = normalColor;
	}


	void OnMouseEnter()
	{
		Debug.Log("Enter");
		StartCoroutine(Fade(normalColor, highlighedColor, fadeTime));
		if(clip != null)
			source.PlayOneShot(clip);
	}
	void OnMouseExit()
	{
		StartCoroutine(Fade(highlighedColor, normalColor, fadeTime));

	}
	void OnMouseDown()
	{
		StartCoroutine(Fade(highlighedColor, pressedColor, fadeTime));
		click();
	}

	void click()
	{
		Debug.Log("cick");
		if (!isExit)
			SceneManager.LoadScene(scene);
		//Fullfills Implementation 2
		else if (isExit && scene < 0)
		{
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
		}
		LoadingFade.fadeTime = 2f;
		LoadingZoom.fadeTime = 2f;
	}

	//Fade script originally made by merlinmarijn
	//Title- How do i fade a object in/out over time?
	//Site - Unity Forums 
	//Date - August 3, 2015
	//Link - https://forum.unity.com/threads/how-do-i-fade-a-object-in-out-over-time.361492/
	//I spent so long trying to do this. This man is the the new god for creating this script.
	IEnumerator Fade(Color start, Color end, float duration)
	{
		for (float t = 0f; t < duration; t += Time.deltaTime)
		{
			float normalizedTime = t / duration;
			if (img != null)
				img.color = Color.Lerp(start, end, normalizedTime);
			else
				txt.color = Color.Lerp(start, end, normalizedTime);
				// Debug.Log("Change Color");
			yield return null;
			if (img != null)
				img.color = end; //without this, the value will end at something like 0.9992367
			else
				txt.color = end;
		}
	}

}
