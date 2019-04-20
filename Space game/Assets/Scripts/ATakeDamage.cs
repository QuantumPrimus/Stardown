using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATakeDamage : MonoBehaviour {
    Explodable ex;


    void Start () {
        ex = GetComponent<Explodable>();
	}

	void Update () {
		
	}



    private void OnTriggerEnter2D(Collider2D collision)
    {
        ex.generateFragments();
        if (collision.gameObject.tag != "Player")
        {
            Debug.Log("Hit");
            if (transform.localScale.x > 2)
                {
                    //Add way for larger asteroids to break into a couple 
                }
            ex.explode();
           //GameObject.Destroy(gameObject);
        }


    }

}
