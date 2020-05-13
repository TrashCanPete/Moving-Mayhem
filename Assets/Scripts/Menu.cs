using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public void LoadScene(int _Level)
    {
        SceneManager.LoadScene(_Level);
    }
    public void ExitScene()
    {
        Application.Quit();
    }
}
