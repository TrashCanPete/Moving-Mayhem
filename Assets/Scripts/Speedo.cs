using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Speedo : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    Text text;
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Mathf.RoundToInt(rb.velocity.magnitude * 2.2369f).ToString();
    }
}
