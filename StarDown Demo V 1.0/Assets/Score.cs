using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour {
    private static Text txt;
    private int score;
    public float scoreMultiplier;

    private float gameScore;
    private float gameTime;
    void Start() {
        txt = GetComponent<Text>();
	}
	
	void Update() {

        gameScore += scoreMultiplier;
        // Debug.Log(gameScore);
        string nValue = ((int)(gameScore)).ToString();
        txt.text = nValue;
        // updateScore();
    }

    
    public void updateScore()
    {
        // gameScore += value;
        string nValue = (gameScore).ToString();
        txt.text = nValue;
    }
    public void addScore(int value)
    {
        gameScore += value;
    }
}
