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
    public static float timer;
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
            timer++;
        }
        int timerInt = Convert.ToInt32(timer);
        timerUI.text = "" + timerInt;
        if (timer < 5)
        {
            TimeSpan time =TimeSpan.FromSeconds(timer);
            timerUI.text = time.ToString(@"s\.f");
        }
        if(pause == false)
        {
            TimerCountDown();
        }
        if(timer <= 0)
        {
            timerUI.text = "Time's Up!";
            pause = true;
            Invoke("TimesUp", 5);
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

    void TimesUp()
    {
#if !UNITY_EDITOR
        GameAnalytics.NewResourceEvent(GAResourceFlowType.Source, "Points", Score.Points, "Mowed_Grass", "score_G");
#endif
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void SetPauseState(bool isPaused)
    {
        pause = isPaused;
    }
}
