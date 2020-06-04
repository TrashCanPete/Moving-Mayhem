using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseObj;
    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            isPaused = !isPaused;
            pauseObj.SetActive(isPaused);
            Time.timeScale = isPaused ? 0 : 1;
        }
    }
}
