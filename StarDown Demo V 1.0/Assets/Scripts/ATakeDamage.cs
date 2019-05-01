using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATakeDamage : MonoBehaviour {
    Explodable ex;
    GameObject score;
    public int pointValue = 400;

    void Start()
    {
        ex = GetComponent<Explodable>();
        score = GameObject.FindGameObjectWithTag("Score");
        Debug.Log(score);
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
            Debug.Log(pointValue);
            score.GetComponent<Score>().addScore(pointValue);
            //GameObject.Destroy(gameObject);
        }
        else
        {
            ex.explode();
        }


    }

}
