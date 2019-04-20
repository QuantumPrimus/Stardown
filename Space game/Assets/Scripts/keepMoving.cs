using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepMoving : MonoBehaviour {
    Rigidbody2D rb;
    // private bool fragmentsExploded = false;
    // Use this for initialization
    void Start () {
       
	}
	

    public void create(Rigidbody2D _rb)
    {
        rb = _rb;
    }
    public void done()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Random.Range(-0.5f,-0.1f), Random.Range(-0.3f, 0.3f));
        Debug.Log(rb.velocity);
        // fragmentsExploded = true;
    }
}
