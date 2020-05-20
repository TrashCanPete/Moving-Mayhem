using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameAnalyticsSDK;
public class Score : MonoBehaviour
{
    public static int points;
    public Text scoreText;
    void Start()
    {
        points = 0;
    }
    void Update()
    {
        scoreText.text = (""+ points);
    }
}
