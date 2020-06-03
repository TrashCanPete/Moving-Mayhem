using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TakeScore : MonoBehaviour
{
    public TextMeshProUGUI text;
    public void SendScore()
    {
        Highscores.AddNewHighscore(text.text, Score.Points);
    }
}
