using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Motor : MonoBehaviour
{
    [SerializeField] LayerMask drivingLayers;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void PowerMotor(float power)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 0.26f, drivingLayers))
        {
            Vector3 hitNormal = hit.normal;
            Vector3 hitTangent = Vector3.ProjectOnPlane(transform.forward, hitNormal);
            rb.AddForce(hitTangent * power);
            Debug.Log(hitTangent);
            Debug.DrawRay(hit.point + (Vector3.up * 0.01f), hitTangent);
        }
    }
}
