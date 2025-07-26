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
               LoadScene("MainScene");
    }


    public void StartFlappyBird()
    {
            LoadScene(flappyBird);
    }

    public void StartMiniGame()
    {
        LoadScene(miniGame);
    }
}
