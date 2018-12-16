using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverSound : MonoBehaviour {

	private AudioSource source;
	public AudioClip clip;


	void Start () {
		source = GameObject.FindGameObjectWithTag("Audio Source").GetComponent<AudioSource>();
	}
	
	void Update () {
		
	}

	private void OnMouseEnter()
	{
		source.PlayOneShot(clip);
	}

	private void OnMouseExit()
	{
		source.Stop();
	}
}
