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
    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 0.27f))
        {
            Vector3 vel = rb.velocity;
            vel = transform.InverseTransformVector(vel);
            float sidewaysVelocity = vel.x;
            rb.AddForceAtPosition(transform.right * -sidewaysVelocity * multi, hit.point, ForceMode.Force);
        }
    }
}
