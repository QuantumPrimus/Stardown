using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testAnimation : MonoBehaviour {

    private Animator anim;

    void Start () {
        anim = GetComponent<Animator>();
	}
	
	void Update () {


        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetBool("Start", true);
            
        }


	}
}
