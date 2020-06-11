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
        AnalyticsController.Controller.SendScore();
        AnalyticsController.Controller.SendName(text.text);
        AnalyticsController.Controller.CharacterID(characterNumber);
        {
#if !UNITY_EDITOR
        
            

#endif
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        Highscores.AddNewHighscore(text.text, Score.Points);
    }
}
