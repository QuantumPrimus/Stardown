using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {



    public float scoreMultiplier;

    private int gameScore;
    private float gameTime;
    private Score score;


    void Start () {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
    }
	
	void Update () {
        // gameTime += Time.deltaTime;
        // gameScore = (int)Mathf.Floor(gameTime * scoreMultiplier);
        // gameScore = Mathf.Floor(gameScore);
        // score.updateScore();
        // Debug.Log(gameScore);


	}
}
