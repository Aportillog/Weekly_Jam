using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    float score;

    public Text scoreText;

	// Use this for initialization
	void Start () {
        score = 0;
        AddScore(score);
	}

    void Update()
    {
    }

    public void AddScore(float amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }
}
