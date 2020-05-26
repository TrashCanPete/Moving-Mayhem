using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animator anim;
    private Driving driving;
    private Steering steering;
    public Timer timerScript;

    // Start is called before the first frame update
    void Start()
    {
        driving = GetComponent<Driving>();
        steering = GetComponent<Steering>();
    }

    // Update is called once per frame
    void Update()
    {
        if (steering.xAxis > 0)
            {
                anim.SetBool("Right Turn", true);
                anim.SetBool("Left Turn", false);
            }
        else if (steering.xAxis < 0)
            {
                anim.SetBool("Left Turn", true);
                anim.SetBool("Right Turn", false);
            }
        else
        {
            anim.SetBool("Left Turn", false);
            anim.SetBool("Right Turn", false);
        }

        if (steering.xAxis > 0 && Input.GetButtonDown("Handbrake"))
        {
            anim.SetBool("Drift Right", true);
            anim.SetBool("Drift Left", false);
        }

        if (steering.xAxis < 0 && Input.GetButtonDown("Handbrake"))
        {
            anim.SetBool("Drift Left", true);
            anim.SetBool("Drift Right", false);
        }

        else if (Input.GetButtonUp("Handbrake"))
        {
            anim.SetBool("Drift Left", false);
            anim.SetBool("Drift Right", false);
        }

        if (driving.Reversing == false)
        {
            anim.SetBool("Reversing", false);
        }
        if (driving.Reversing == true)
        {
            anim.SetBool("Reversing", true);
        }

        if (timerScript.timer <= 0)
        {
            anim.SetTrigger("Finish Game");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Obstacle" && driving.Reversing == false)
        {
            anim.SetTrigger("Crashing");
        }
        else if (collision.gameObject.tag == "Obstacle" && driving.Reversing == true)
        {
            anim.SetTrigger("Reverse Crashing");
        }
    }
    
}
