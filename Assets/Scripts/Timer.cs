using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text timerUI;
    private float timer;
    public bool pause;
    [SerializeField]
    private float startTimerValue;
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
