using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameAnalyticsSDK;
using TMPro;
public class Score : MonoBehaviour
{
    static bool scoring = false;
    static int points;
    static int pointTracker;
    float vel = 0;
    public static int Points
    {
        get { return points; }
        set 
        {
            if (value > points)
                scoring = true;
            points = value;
        }
    }
    public TextMeshProUGUI scoreText;
    float desiredScale = 1;
    const float maxSize = 2f;
    const float minSize = 1f;
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        Points = 0;
    }
    void Update()
    {
        if (scoring)
        {
            desiredScale = maxSize;
            vel = 0;
            scoring = false;
        }
        scoreText.text = ("" + Points);
        SetSize();
    }
    void SetSize()
    {
        transform.localScale = new Vector3(desiredScale, desiredScale, 1);
        desiredScale = Mathf.SmoothDamp(desiredScale, minSize, ref vel, 0.5f);
    }

}
