using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GameAnalyticsSDK;
using GameAnalyticsSDK.Setup;
using GameAnalyticsSDK.Events;
using TMPro;
public class Timer : MonoBehaviour
{
    private TextMeshProUGUI timerUI;
    [SerializeField]
    public static float timeRemaining;
    public bool pause;
    [SerializeField]
    private float startTimerValue;
    public Score score;

    int timesadded = 1;
    int targetPoints = 50;
    public int pointsToGetMoreTime;


    void Start()
    {
        ResetTimer();
        timerUI = GetComponent<TextMeshProUGUI>();
        timerUI.text = startTimerValue.ToString();
    }

    void Update()
    {
        
        pointsToGetMoreTime = timesadded * targetPoints;
        if(Score.Points > timesadded * targetPoints)
        {
            timesadded++;
            timeRemaining++;
        }
        TimeSpan time = TimeSpan.FromSeconds(timeRemaining);
        timerUI.text = time.ToString(@"m\:ss");
        if (timeRemaining < 5)
        {
            timerUI.text = time.ToString(@"s\.f");
        }
        if(pause == false)
        {
            TimerCountDown();
        }
        if(timeRemaining <= 0)
        {
            timerUI.text = "Time's Up!";
            pause = true;
            Invoke("TimesUp", 5);
        }
    }
    void ResetTimer()
    {
        timeRemaining = startTimerValue;
    }
    void TimerCountDown()
    {
        timeRemaining -= 1 * Time.deltaTime;
    }

    void TimesUp()
    {
#if !UNITY_EDITOR                                                 //currency   //amount    //item type   //item ID
        GameAnalytics.NewResourceEvent(GAResourceFlowType.Source, "Points", Score.Points, "Mowed_Grass", "score_G");
#endif
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void SetPauseState(bool isPaused)
    {
        pause = isPaused;
    }
}
