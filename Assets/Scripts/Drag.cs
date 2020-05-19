using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    Rigidbody rb;
    public float factor;
    [SerializeField] Driving driving;
    [SerializeField] AnimationCurve driftFactor;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (driving.IsGrounded)
        {
            Vector3 vel = rb.velocity;
            vel = transform.InverseTransformVector(vel);
            float force = rb.mass * vel.x;
            float drift = driftFactor.Evaluate(driving.DriftFactor);
            force = force * (1 - drift);
            rb.AddForce(-transform.right * force * factor, ForceMode.Force);
        }
    }
}
