using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseObj;
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            isPaused = !isPaused;
            if (isPaused == true)
            {
                Time.timeScale = 0;
                pauseObj.SetActive(true);
            }
            else if (isPaused == false)
            {
                Time.timeScale = 1;
                pauseObj.SetActive(false);
            }
        }
        /*if (Input.GetButtonDown("Pause"))
        {
            isPaused = !isPaused;
            pauseObj.SetActive(isPaused);
            Time.timeScale = isPaused ? 0 : 1;
        }*/


    }
}
