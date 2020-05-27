using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public DontDestroyOnLoad dontDestroy;
    public GameObject crunchCamera;
    public Canvas renderCanvas;
    //DisplayHighscores displayhighscores;
    private void Start()
    {
        dontDestroy = FindObjectOfType<DontDestroyOnLoad>().GetComponent<DontDestroyOnLoad>();
        crunchCamera = GameObject.FindGameObjectWithTag("CrunchCamera");
        renderCanvas = GetComponent<Canvas>();
    }
    public void LoadScene(int _Level)
    {
        dontDestroy.setActiveCanvas = false;
        SceneManager.LoadScene(_Level);
        
    }
    public void ExitScene()
    {
        Application.Quit();
    }
}
