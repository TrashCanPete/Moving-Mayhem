using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePlayer : MonoBehaviour
{
    public static Rigidbody playerRB;
    public void Deactivate()
    {
        playerRB.isKinematic = true;
    }
    public void Activate()
    {
        playerRB.isKinematic = false;
    }
}
