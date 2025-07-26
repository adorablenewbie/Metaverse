using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour, IInteractable
{
    public GameObject miniGamePanel;

    public void Interact()
    {
        if (miniGamePanel != null)
        {
            miniGamePanel.SetActive(true);
            Time.timeScale = 0f; // 게임 일시 정지
        }
        else
        {
            Debug.LogWarning("MiniGame panel is not assigned.");
        }
    }
    public void CloseUI()
    {
        if (miniGamePanel != null)
        {
            miniGamePanel.SetActive(false);
            Time.timeScale = 1f; // 게임 시간 재개
        }
        else
        {
            Debug.LogWarning("MiniGame panel is not assigned.");
        }
    }



}
