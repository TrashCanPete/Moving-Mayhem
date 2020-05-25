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

    public DontDestroyOnLoad dontDestroy;

    // Start is called before the first frame update
    void Start()
    {
        dontDestroy = FindObjectOfType<DontDestroyOnLoad>().GetComponent<DontDestroyOnLoad>();
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
            string username = "";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            for (int i = 0; i < 3; i++)
            {
                username += alphabet[UnityEngine.Random.Range(0, alphabet.Length)];
            }
            Highscores.AddNewHighscore(username,Score.points);
            GameAnalytics.NewResourceEvent(GAResourceFlowType.Source, "Points", Score.points,"Mowed_Grass","score_G");
            //Reset to main menu scene
            dontDestroy.setActiveCanvas = true;
            SceneManager.LoadScene(0);
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
