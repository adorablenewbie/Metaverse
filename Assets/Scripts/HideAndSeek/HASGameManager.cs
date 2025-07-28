using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HideAndSeekMode
{
    Playing,
    None

}
public class HASGameManager : MonoBehaviour
{
    static HASGameManager gameManager;
    public static HASGameManager instance
    {
        get { return gameManager; }
    }

    public GameObject chekcObj;

    public GameObject heo;
    public GameObject jeong;
    public GameObject choo;
    public GameObject kang;
    public GameObject lee;

    public HideAndSeekMode hideAndSeekMode;

    SpawnNPC spawnNPC;
    HASUIManager hASUIManager;


    void Awake()
    {
        gameManager = this;
        spawnNPC = FindObjectOfType<SpawnNPC>();
        hASUIManager = FindObjectOfType<HASUIManager>();

    }
    void Start()
    {
        spawnNPC.Spawn(heo, chekcObj);
        spawnNPC.Spawn(jeong, chekcObj);
        spawnNPC.Spawn(lee, chekcObj);
        spawnNPC.Spawn(choo, chekcObj);
        spawnNPC.Spawn(kang, chekcObj);
        hideAndSeekMode = HideAndSeekMode.Playing;
        
    }

    void Update()
    {
        if (hideAndSeekMode == HideAndSeekMode.Playing) hASUIManager.TimeScore();
    }
    public void CheckWin()
    {
        if(chekcObj.transform.childCount <= 1)
        {
            hideAndSeekMode = HideAndSeekMode.None;
            hASUIManager.SetWinUI();
            Invoke("LoadMainScene", 5f);
        }
    }
    public void LoadMainScene()
    {
        LoadSceneManager.Instance.GoMainScene();
    }

}
