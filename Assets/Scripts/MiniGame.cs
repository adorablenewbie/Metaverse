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
            Time.timeScale = 0f; // ���� �Ͻ� ����
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
            Time.timeScale = 1f; // ���� �ð� �簳
        }
        else
        {
            Debug.LogWarning("MiniGame panel is not assigned.");
        }
    }



}
