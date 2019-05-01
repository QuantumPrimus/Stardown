using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingZoom : MonoBehaviour {
	public static float fadeTime;
	public float zoomOutSize;
	// private float zoomInSize;

	private Camera cam;
	

	void Start () {
		cam = GetComponent<Camera>();
		cam.orthographicSize = 0f;
		StartCoroutine(Fade(zoomOutSize, fadeTime));
	}
	
	void Update () {
		
	}


	IEnumerator Fade(float zoom, float time)
	{
		float size = cam.orthographicSize;
		for(float t = 0; t <= 1; t += Time.deltaTime / time)
		{
			float newSize = Mathf.Lerp(size, zoom, t);
			cam.orthographicSize = newSize;

			yield return null;
		}

		cam.orthographicSize = zoom;

	}


}

