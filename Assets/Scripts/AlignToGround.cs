using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignToGround : MonoBehaviour
{
    [SerializeField] LayerMask layers;
    [SerializeField] float multi;
    [SerializeField] float airMultiplier;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        RaycastHit hit;
        float force = multi;
        Vector3 alignment = Vector3.up;
       if(Physics.Raycast(transform.position,-transform.up,out hit, 2.5f, layers, QueryTriggerInteraction.Ignore))
        {
            alignment = hit.normal;
            Debug.DrawRay(hit.point, hit.normal);
        }
        else
        {
            force = multi * airMultiplier;
        }
        rb.AddTorque(Vector3.Cross(transform.up, alignment)*force);
    }
}
