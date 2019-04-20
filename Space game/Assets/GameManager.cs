using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {



    public float scoreMultiplier;

    private float gameScore;
    private float gameTime;
    


	void Start () {
		
	}
	
	void Update () {
        gameTime += Time.deltaTime;
        gameScore = gameTime * scoreMultiplier;
        gameScore = Mathf.Floor(gameScore);
        Score.updateScore(gameScore);
        // Debug.Log(gameScore);


	}
}
