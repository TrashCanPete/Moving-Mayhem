using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public DontDestroyOnLoad dontDestroy;
    public GameObject crunchCamera;
    public Canvas renderCanvas;
    public GameObject highScoresGroup;


    private void Start()
    {
        dontDestroy = FindObjectOfType<DontDestroyOnLoad>().GetComponent<DontDestroyOnLoad>();
        crunchCamera = GameObject.FindGameObjectWithTag("CrunchCamera");
        renderCanvas = GetComponent<Canvas>();
        StartCoroutine(SwitchScoresGroupOn());
        
    }

    private void Update()
    {
        if (SceneManager.GetSceneByName("Menu Scene").isLoaded && (Input.anyKey))
        {
            LoadScene(1);
        }
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

    public IEnumerator SwitchScoresGroupOn()
    {
        yield return new WaitForSeconds(3f);
        highScoresGroup.SetActive(true);
        StartCoroutine(SwitchOffScoresGroup());
    }
    
    void SetScoresActive()
    {
        highScoresGroup.SetActive(true);
        StartCoroutine(SwitchOffScoresGroup());
    }

    public IEnumerator SwitchOffScoresGroup()
    {
        yield return new WaitForSeconds(9.9f);
        highScoresGroup.SetActive(false);
        StartCoroutine(SwitchScoresGroupOn());
    }

}
