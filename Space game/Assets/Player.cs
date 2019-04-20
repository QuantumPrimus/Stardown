using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private int health = 3;
    private GameObject[] hearts;
    private PolygonCollider2D col;


    void Start() {
        hearts = GameObject.FindGameObjectsWithTag("Heart");
        col = GetComponent<PolygonCollider2D>();
    }

    void Update() {

    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(col);
        health--;
        hearts[health].GetComponent<Animator>().SetBool("Start", true);
        gameObject.AddComponent<PolygonCollider2D>();
    }



    private IEnumerator invinsFrames()
    {


        yield return null;
    }
}
