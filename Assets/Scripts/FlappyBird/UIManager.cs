using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Image gameOverImg;
    public Text currScore;
    public Text bestScore;
    public Text restartText;

    public void Start()
    {
        if (restartText == null)
        {
            Debug.LogError("restart text is null");
        }

        if (scoreText == null)
        {
            Debug.LogError("scoreText is null");
            return;
        }

        gameOverImg.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }

    public void SetRestart()
    {
        scoreText.gameObject.SetActive(false);
        gameOverImg.gameObject.SetActive(true);
        currScore.text = scoreText.text;
        int best = PlayerPrefs.GetInt("BestScore", 0);
        int currentScore = int.Parse(scoreText.text);
        if (currentScore > best)
        {
            PlayerPrefs.SetInt("BestScore", currentScore);
            best = currentScore;
        }
        bestScore.text = best.ToString();
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}