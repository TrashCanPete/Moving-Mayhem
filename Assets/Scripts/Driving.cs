using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driving : MonoBehaviour
{
    public float enginePower;
    [SerializeField] Motor[] motors;
    float zAxis;
    private void Update()
    {
        zAxis = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        float power = enginePower * zAxis;
        for(int i =0; i < motors.Length; i++)
        {
            motors[i].PowerMotor(power);
        }
    }
}
