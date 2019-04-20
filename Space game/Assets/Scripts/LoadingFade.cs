using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadingFade : MonoBehaviour {

	public static float fadeTime = 1;

	private Text txt;
	private Image img;

	void Start() {
		img = GetComponent<Image>();
		// txt = GetComponentInChildren<Text>();
		img.color = new Color(img.color.r, img.color.g, img.color.b, 0f);
		txt.color = new Color(255, 255, 255, 0f);
		StartCoroutine(toAlpha(1f, fadeTime));
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log("Pressed");
			StartCoroutine(toAlpha(0f,fadeTime));
		}
		
	}


	IEnumerator toAlpha(float val, float time)
	{
		float alpha = img.color.a;
		for (float t = 0f; t <= 1f; t += Time.deltaTime / time)
		{
			Color newColor = new Color(img.color.r, img.color.g, img.color.b, Mathf.Lerp(alpha, val, t));
			img.color = newColor;
			if(txt != null)
				txt.color = newColor;
			yield return null;
		}
		img.color = new Color(img.color.r, img.color.g, img.color.b, val);
		if (txt != null)
			txt.color = img.color;
	}
}
