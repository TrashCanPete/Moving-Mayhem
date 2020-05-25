using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GameAnalyticsSDK;
using GameAnalyticsSDK.Setup;
using GameAnalyticsSDK.Events;

public class Timer : MonoBehaviour
{
    private Text timerUI;
    [SerializeField]
    private float timer;
    public bool pause;
    [SerializeField]
    private float startTimerValue;
    public Score score;



    // Start is called before the first frame update
    void Start()
    {

        ResetTimer();
        pause = false;
        timerUI = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        int timerInt = Convert.ToInt32(timer);
        timerUI.text = "" + timerInt;

        if(pause == false)
        {
            TimerCountDown();
        }
        if(timer <= 0)
        {
            /*//name generator
             * string username = "";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            for (int i = 0; i < 3; i++)
            {
                username += alphabet[UnityEngine.Random.Range(0, alphabet.Length)];
            }
            */
            GameAnalytics.NewResourceEvent(GAResourceFlowType.Source, "Points", Score.points, "Mowed_Grass", "score_G");
            //Reset to main menu scene

            SceneManager.LoadScene(3);
        }
    }
    void ResetTimer()
    {
        timer = startTimerValue;
    }
    void TimerCountDown()
    {
        timer -= 1 * Time.deltaTime;
    }
}
