using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour, IInteractable
{
    public GameObject nPC;
    public GameObject nPCPanel;
    public Text nPCText;


    //List<string> heoDialogue = new List<string>();
    List<string> heoDialogue = new List<string>() {"허허", "어떻게 이름 초성이 ㅎㅇ", "건방진 코노야로구나...", "화장실좀", "화장실 한 번만 더" };
    List<string> jeongDialogue = new List<string>() { "네?", "네에?", "(가습기 가동 중)", "네에에?", "네에에에?" };

    public void Interact()
    {
        Debug.Log("상호작용");
        Time.timeScale = 0f;
        if (nPCPanel.activeSelf)
        {
            CloseUI();
            return;
        }
        if (nPC.CompareTag("Heo"))
        {
            nPCPanel.SetActive(true);
            int select = Random.Range(0, heoDialogue.Count);
            nPCText.text = heoDialogue[select];
        }
        if (nPC.CompareTag("Jeong"))
        {
            nPCPanel.SetActive(true);
            int select = Random.Range(0, jeongDialogue.Count);
            nPCText.text = jeongDialogue[select];
        }
    }
    
    public void CloseUI()
    {
        nPCPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
