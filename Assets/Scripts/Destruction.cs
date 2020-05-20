using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    public GameObject piece1;
    public GameObject piece2;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player colliding");
            Instantiate(piece1, transform.position + (transform.up * 1.5f), transform.rotation);
            Instantiate(piece2, transform.position + (transform.up * 1.5f), transform.rotation);
            Invoke("destroy", 0.05f);
        }
    }
    void destroy()
    {
        Destroy(this.gameObject);
    }
}
