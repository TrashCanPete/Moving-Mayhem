using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DisplayHighscores : MonoBehaviour
{
    public TMP_Text[] highscoreTexts;
    Highscores highscoreManager;
    [SerializeField]
    private string columnSpace = "            ";

    void Start()
    {
        for (int i = 0; i < highscoreTexts.Length; i ++)
        {
            highscoreTexts[i].text = i + 1 + ". Fetching...";
        }
        highscoreManager = GetComponent<Highscores>();
        StartCoroutine(RefreshHighscores());
    }

    public void OnHighscoresDownloaded(Highscore[] highscoreList)
    {
        for (int i = 0; i < highscoreTexts.Length; i++)
        {
            highscoreTexts[i].text = i + 1 + "";
            if(highscoreList.Length > i)
            {
                highscoreTexts[i].text += columnSpace + highscoreList[i].username + columnSpace + highscoreList[i].score;
            }
        }
    }
    IEnumerator RefreshHighscores()
    {
        while (true)
        {
            highscoreManager.DownloadHighscores();
            yield return new WaitForSeconds(30);
        }
    }

}
