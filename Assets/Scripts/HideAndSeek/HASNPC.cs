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
        }
    }
    public void CloseUI()
    {
        nPCPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
