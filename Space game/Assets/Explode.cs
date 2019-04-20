using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Explode : MonoBehaviour {

    Explodable ex;

    // Use this for initialization
    void Start () {
        ex = GetComponent<Explodable>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        ex.explode();
        // GetComponent<fadeParticles>().fadeObject();
    }
}
