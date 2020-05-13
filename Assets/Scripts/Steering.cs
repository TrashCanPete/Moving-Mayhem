using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering : MonoBehaviour
{
    public float steeringAngle;
    [SerializeField] Transform[] SteeringWheels;
    float xAxis;
    private void Update()
    {
        xAxis = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        Vector3 angle = new Vector3 (0,steeringAngle * xAxis,0);

        for (int i = 0; i < SteeringWheels.Length; i++)
        {
            SteeringWheels[i].transform.rotation = transform.rotation;
            Vector3 rot = SteeringWheels[i].rotation.eulerAngles;
            rot = rot + angle;
            SteeringWheels[i].rotation = Quaternion.Euler(rot);
        }
    }
}
