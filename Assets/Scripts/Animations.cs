using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animator anim;
    public Driving driving;
    public Steering steering;

    // Start is called before the first frame update
    void Start()
    {
        driving = GetComponent<Driving>();
    }

    // Update is called once per frame
    void Update()
    {
        if (driving.Reversing == false)
        {
            anim.SetBool("Reversing", false);
        }
        if (driving.Reversing == true)
        {
            anim.SetBool("Reversing", true);
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
