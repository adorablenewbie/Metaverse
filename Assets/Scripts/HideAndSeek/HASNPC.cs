using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HASNPC : MonoBehaviour, IInteractable
{
    public GameObject nPC;
    public GameObject nPCPanel;
    public Text nPCText;


    List<string> heoPlayDialogue = new List<string>() { "이걸 찾네 ㄷㄷ", "ㅎㅇ...", "날 찾다니 건방진 코노야로구나...", "이제 화장실 좀", "이제 날 찾지 마요" };
    List<string> jeongPlayDialogue = new List<string>() { "이걸 찾 네?", "이걸 찾 네에?", "가습기 때문에 들켰네", "에에?", "에에에?" };
    List<string> kangPlayDialogue = new List<string>() { "어케 찾음 ㄷㄷ", "램이 너무 밝아서 들킴 ㄷㄷ", "Debug.Log(\"이걸 찾네 ㄷㄷ\")", "아~ 귀찮음~~", "버그아님?" };
    List<string> leePlayDialogue = new List<string>() { "진짜 신고할게요", "진짜 진짜 고소할게요", "불쾌하네요", "진짜 죽일게요", "사과하세요" };
    List<string> chooPlayDialogue = new List<string>() { "안녕하세요 유니티 11기 아이돌 쩌기쩌기 쩌기쩌입니다",
        "안녕하세요 유니티 11기 아이돌 흘깃흘깃 흘깃추입니다.",
        "젭라 살려줌메 퓨ㅠㅠㅠㅠㅠ", "ㅇㄱㅈㅉㅇㅇ???", "(가방 던지는 중)" };


    public void Interact()
    {
        Debug.Log("상호작용");
        Time.timeScale = 0f;
        if (nPCPanel.activeSelf)
        {
            if (HASGameManager.instance.hideAndSeekMode == HideAndSeekMode.Playing)
            {
                Destroy(nPC);
                HASGameManager.instance.CheckWin();
            }
            CloseUI();
            return;
        }

        if (HASGameManager.instance.hideAndSeekMode == HideAndSeekMode.Playing)
        {
            if (nPC.CompareTag("Heo"))
            {
                nPCPanel.SetActive(true);
                int select = Random.Range(0, heoPlayDialogue.Count);
                nPCText.text = heoPlayDialogue[select];
            }
            if (nPC.CompareTag("Jeong"))
            {
                nPCPanel.SetActive(true);
                int select = Random.Range(0, jeongPlayDialogue.Count);
                nPCText.text = jeongPlayDialogue[select];
            }
            if (nPC.CompareTag("Choo"))
            {
                nPCPanel.SetActive(true);
                int select = Random.Range(0, chooPlayDialogue.Count);
                nPCText.text = chooPlayDialogue[select];
            }
            if (nPC.CompareTag("Kang"))
            {
                nPCPanel.SetActive(true);
                int select = Random.Range(0, kangPlayDialogue.Count);
                nPCText.text = kangPlayDialogue[select];
            }
            if (nPC.CompareTag("Lee"))
            {
                nPCPanel.SetActive(true);
                int select = Random.Range(0, leePlayDialogue.Count);
                nPCText.text = leePlayDialogue[select];
            }
        }
    }
    public void CloseUI()
    {
        nPCPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
