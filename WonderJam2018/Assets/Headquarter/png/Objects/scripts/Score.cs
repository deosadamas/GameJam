using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public GUIText scoreText;
	public int coinValue;

	private int score;

    void Start()
    {
        score = 0;
        UpdateScore();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        score += coinValue;
        UpdateScore();
    }


    void UpdateScore()
    {
        scoreText.text = "SCORE:\n" + score;
    }
}

