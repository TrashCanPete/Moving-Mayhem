using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpToPos : MonoBehaviour
{
    [SerializeField] Transform target;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, 0.1f);
    }
}
