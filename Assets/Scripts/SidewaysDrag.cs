using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidewaysDrag : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float multi;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionStay(Collision collision)
    {
        Vector3 vel = rb.velocity;
        vel = transform.InverseTransformVector(vel);
        float sidewaysVelocity = vel.x;
        rb.AddForceAtPosition(transform.right * -sidewaysVelocity *  multi,collision.contacts[0].point,ForceMode.Force);
    }
}
