using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    public static LoadSceneManager Instance { get; private set; }

    public string flappyBird = "FlappyBirdScene";
    public string miniGame;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void GoMainScene()
    {
        Time.timeScale = 1f; // 게임 시간 재개
        LoadScene("MainScene");
    }


    public void StartFlappyBird()
    {
        Player.playerPosition = new Vector3(0, 29, 0);
        Time.timeScale = 1f; // 게임 시간 재개
        LoadScene(flappyBird);
    }

    public void StartMiniGame()
    {
        Player.playerPosition = new Vector3(0, 29, 0);
        Time.timeScale = 1f; // 게임 시간 재개
        LoadScene(miniGame);
    }
}
