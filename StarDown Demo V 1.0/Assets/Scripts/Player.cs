using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    private Explodable ex;
    private int health = 0;
    private GameObject[] hearts;
    private PolygonCollider2D col;
    private bool isInvis = false;
    [SerializeField]
    private float invisTime = 1.1f;
    private float time = 0;
    private GameObject[] go;
    private Text[] txt = new Text[2];
    private bool alive = true;
    void Start() {
        int index = 0;
        ex = GetComponent<Explodable>();
        hearts = GameObject.FindGameObjectsWithTag("Heart");
        go = GameObject.FindGameObjectsWithTag("Game Over");
        
        foreach (GameObject g in go)
        {
            txt[index] = g.GetComponent<Text>();
            index++;
        }
        Debug.Log(txt[0]);   
        // col = GetComponent<PolygonCollider2D>();
        // hearts[0].SetActive(false);
    }

    void Update() {
        if (isInvis && Time.time > time && health >= 0)
        {
            // Debug.Log(hearts[health]);
            hearts[health].SetActive(false);
            health--;
            isInvis = false;
        }
           
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Destroy(col);
        if (!isInvis && health >= 0)
        {
            Debug.Log("Here");
            isInvis = true;
            hearts[health].GetComponent<Animator>().SetBool("Start", true);
            time = Time.time + invisTime;
        }
        if (health < 0)
        {
            ex.generateFragments();
            ex.explode();
            GameObject.Find("Thrust").transform.position = new Vector2(2000,2000);
            alive = false;
            setGameOver();
            
            // gameObject.GetComponent<PlayerController>().speed = 0;
            //Game Over
            // Debug.Log("here");
            // GameObject.Find("Game Over").SetActive(true);
        }

        // if(!invis)
        // hearts[health].SetActive(false);
        // gameObject.AddComponent<PolygonCollider2D>();
        // gameObject.GetComponent<PolygonCollider2D>(). = true;
    }

    private void setGameOver()
    {
        foreach(Text t in txt)
            t.color = new Color(255, 255, 255, 255);
        GameOver.setAliveState(alive);
        
    }

}
