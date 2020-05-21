using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    public GameObject piece1;
    public GameObject piece2;

    private Vector3 playerPos;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player colliding");
            Instantiate(piece1, playerPos , transform.rotation);
            Instantiate(piece2, playerPos , transform.rotation);
            Invoke("destroy", 0.05f);
        }
    }
    void destroy()
    {
        Destroy(this.gameObject);
    }
}
