using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignToGround : MonoBehaviour
{
    [SerializeField] LayerMask layers;
    [SerializeField] float groundMultiplier;
    [SerializeField] float airMultiplier;
    [SerializeField] float selfRighting;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        RaycastHit hit;
        float force = groundMultiplier;
        Vector3 alignment = Vector3.up;
       if(Physics.Raycast(transform.position,-transform.up,out hit, 1, layers, QueryTriggerInteraction.Ignore))
        {
            alignment = hit.normal;
            Debug.DrawRay(hit.point, hit.normal);
        }
        else
        {
            force =  airMultiplier;
        }
        float angle = Vector3.Angle(transform.up, Vector3.up);
        if (angle > 90)
            force *= selfRighting;
        rb.AddTorque(Vector3.Cross(transform.up, alignment)*force,ForceMode.Force);
    }
}
