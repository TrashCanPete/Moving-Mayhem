using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class SetCenterOfMass : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] Transform target;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = target.position-rb.position;
    }
}
