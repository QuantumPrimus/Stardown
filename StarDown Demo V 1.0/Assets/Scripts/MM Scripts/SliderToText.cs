using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderToText : MonoBehaviour {
	public Slider slider;
	private Text txt;

	void Start () {
		txt = GetComponent<Text>();
	}
	
	void Update () {
		int intVal = Mathf.RoundToInt(slider.value * 100);
		string val = "" + intVal;
		txt.text = val;
	}
}
