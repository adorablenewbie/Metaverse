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
    List<string> chooDialogue = new List<string>() { "유니티 11기 연예인 쩌기쩌입니다.", "유니티 11기 연예인 흘깃추입니다.", "살려주셈", "젭라 살려줌메 퓨ㅠㅠ", "님님님님님님님" };
    List<string> kangDialogue = new List<string>() { "님도 개발하셈 재밌음~", "C언어 배울바에 어셈블리어 배움 ㅋㅋ", "ㄹㅇㅋㅋ", "(가습기 가동 중)", "네엥?" };
    List<string> leeDialogue = new List<string>() { "신고할게요", "고소할게요", "죽일게요", "몰리야~", "내 홀리몰리 좀 보셈" };

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
        if (nPC.CompareTag("Choo"))
        {
            nPCPanel.SetActive(true);
            int select = Random.Range(0, chooDialogue.Count);
            nPCText.text = chooDialogue[select];
        }
        if (nPC.CompareTag("Kang"))
        {
            nPCPanel.SetActive(true);
            int select = Random.Range(0, kangDialogue.Count);
            nPCText.text = kangDialogue[select];
        }
        if (nPC.CompareTag("Lee"))
        {
            nPCPanel.SetActive(true);
            int select = Random.Range(0, leeDialogue.Count);
            nPCText.text = leeDialogue[select];
        }
    }
    
    public void CloseUI()
    {
        nPCPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
