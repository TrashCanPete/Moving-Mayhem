using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GameAnalyticsSDK;
using GameAnalyticsSDK.Setup;
using GameAnalyticsSDK.Events;
using UnityEngine.SceneManagement;
public class TakeScore : MonoBehaviour
{
    private int characterNumber;
    public TextMeshProUGUI text;
    private void Start()
    {
        characterNumber = CharacterSelectCam.characterIndex +=1;
    }

    public void SendScore()
    {
        {
#if !UNITY_EDITOR                                                 //currency   //amount    //item type   //item ID
        GameAnalytics.NewResourceEvent(GAResourceFlowType.Source, "Points", Score.Points, "Mowed_Grass", "score_ID");
        GameAnalytics.NewResourceEvent(GAResourceFlowType.Source, "Name", text.text, "Player_Initials", "Player_ID");
        GameAnalytics.NewResourceEvent(GAResourceFlowType.Source, "Character", characterNumber, "Character_Type", Character_ID)
#endif
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        Highscores.AddNewHighscore(text.text, Score.Points);
    }
}
