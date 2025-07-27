using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateLeaderBoard : MonoBehaviour
{
    public Text rank1Name;
    public Text rank2Name;
    public Text rank3Name;
    public Text rank4Name;
    public Text rank5Name;
    public Text rank1;
    public Text rank2;
    public Text rank3;
    public Text rank4;
    public Text rank5;

    void Start()
    {
        rank1Name.text = PlayerPrefs.GetString("RankName1", "劳疙");
        rank2Name.text = PlayerPrefs.GetString("RankName2", "劳疙");
        rank3Name.text = PlayerPrefs.GetString("RankName3", "劳疙");
        rank4Name.text = PlayerPrefs.GetString("RankName4", "劳疙");
        rank5Name.text = PlayerPrefs.GetString("RankName5", "劳疙");

        rank1.text = PlayerPrefs.GetInt("Rank1", 0).ToString();
        rank2.text = PlayerPrefs.GetInt("Rank2", 0).ToString();
        rank3.text = PlayerPrefs.GetInt("Rank3", 0).ToString();
        rank4.text = PlayerPrefs.GetInt("Rank4", 0).ToString();
        rank5.text = PlayerPrefs.GetInt("Rank5", 0).ToString();
    }
}
