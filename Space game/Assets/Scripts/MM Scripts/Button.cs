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

	private float t;
	private AudioSource source;
	private Image img;
	void Start () {
		source = GameObject.FindGameObjectWithTag("Audio Source").GetComponent<AudioSource>();
		img = GetComponent<Image>();
		img.color = normalColor;
		t = 0;
	}

	void OnMouseEnter()
	{
		StartCoroutine(Fade(normalColor, highlighedColor, fadeTime));
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
		if (!isExit)
			SceneManager.LoadScene(scene);
		//Fullfills Implementation 2
		else if (isExit && scene < 0)
		{
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit()
		#endif
		}
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
			img.color= Color.Lerp(start, end, normalizedTime);
			yield return null;
		}
		img.color = end; //without this, the value will end at something like 0.9992367
	}

}
