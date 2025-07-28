using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HASUIManager : MonoBehaviour
{
    public float timeScore = 0;
    public Text timeScoreText;
    public GameObject winPanel;
    public Text score;


    public void TimeScore()
    {
        timeScore += Time.deltaTime;
        timeScoreText.text = $"Time: {timeScore:F2}";
        
    }
    public void SetWinUI()
    {
        winPanel.SetActive(true);
        timeScoreText.gameObject.SetActive(false);
        score.text = timeScore.ToString("F2");
    }
}
