using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Image gameOverImg;
    public Image newRecordImg;
    public InputField recordNameInput;
    public Text currScore;
    public Text bestScore;
    public Text firstScore;
    public Text restartText;
    public Text updateRecord;

    private int pendingScore = -1; // 임시 저장 점수

    void Start()
    {
        gameOverImg.gameObject.SetActive(false);
        newRecordImg.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }

    public void SetRestart()
    {
        Debug.Log($"{PlayerPrefs.GetString("RankName1")}");
        Debug.Log($"{PlayerPrefs.GetInt("Rank1")}");
        scoreText.gameObject.SetActive(false);
        gameOverImg.gameObject.SetActive(true);
        currScore.text = scoreText.text;

        int currentScore = int.Parse(scoreText.text);
        int best = PlayerPrefs.GetInt("BestScore", 0);
        if (currentScore > best)
        {
            PlayerPrefs.SetInt("BestScore", currentScore);
        }
        bestScore.text = PlayerPrefs.GetInt("BestScore").ToString();
        firstScore.text = PlayerPrefs.GetInt("Rank1", 0).ToString();

        // 갱신 가능한 점수인지 판단
        if (IsNewHighScore(currentScore))
        {
            pendingScore = currentScore;
            newRecordImg.gameObject.SetActive(true);
        }
        else
        {
            newRecordImg.gameObject.SetActive(false);
        }
    }

    public void SaveNameAndRanking()
    {
        if (pendingScore == -1)
            return;

        string name = recordNameInput.text.Trim();
        if (string.IsNullOrEmpty(name))
            name = "익명";

        UpdateRanking(pendingScore, name);
        pendingScore = -1;

        // 입력창 숨기기
        newRecordImg.gameObject.SetActive(false);
    }

    private bool IsNewHighScore(int score)
    {
        for (int i = 1; i <= 5; i++)
        {
            if (score > PlayerPrefs.GetInt($"Rank{i}", 0))
            {
                updateRecord.text = $"{i}등";
                return true;
            }
        }
        return false;
    }

    private void UpdateRanking(int newScore, string newName)
    {
        int[] scores = new int[5];
        string[] names = new string[5];

        for (int i = 0; i < 5; i++)
        {
            scores[i] = PlayerPrefs.GetInt($"Rank{i + 1}", 0);
            names[i] = PlayerPrefs.GetString($"RankName{i + 1}", "익명");
        }

        int insertIndex = -1;
        for (int i = 0; i < 5; i++)
        {
            if (newScore > scores[i])
            {
                insertIndex = i;
                break;
            }
        }

        if (insertIndex == -1)
            return;

        for (int i = 4; i > insertIndex; i--)
        {
            scores[i] = scores[i - 1];
            names[i] = names[i - 1];
        }

        scores[insertIndex] = newScore;
        names[insertIndex] = newName;

        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt($"Rank{i + 1}", scores[i]);
            PlayerPrefs.SetString($"RankName{i + 1}", names[i]);
        }

        PlayerPrefs.Save();
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
