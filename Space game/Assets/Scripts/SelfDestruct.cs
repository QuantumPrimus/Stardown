using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

	public float lifeSpan = .25f;
	private float timer = 0f;

	// Use this for initialization
	void Start () {
		timer = lifeSpan;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if(timer <= 0f)
		{
			timer = lifeSpan;
			Destroy(gameObject);
		}

	}
}
