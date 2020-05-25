using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NameTransfer : MonoBehaviour
{
    public string theName;
    public GameObject inputField;
    public GameObject textDisplay;

    public DontDestroyOnLoad dontDestroy;

    private void Start()
    {
        dontDestroy = FindObjectOfType<DontDestroyOnLoad>().GetComponent<DontDestroyOnLoad>();
    }

    public void storeName()
    {
        theName = inputField.GetComponent<Text>().text;
        textDisplay.GetComponent<Text>().text = "" + theName;

        Highscores.AddNewHighscore(theName, Score.points);

        dontDestroy.setActiveCanvas = true;
        SceneManager.LoadScene(0);
    }
}
