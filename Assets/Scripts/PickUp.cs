using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public enum TypesOfPickUps {Timer, Multiplyer }
    public TypesOfPickUps pickUpType;
    [SerializeField]
    private int addedTime;


    //floating
    [SerializeField]
    private float degreesPerSecond = 15.0f;
    [SerializeField]
    private float amplitude = 0.5f;
    [SerializeField]
    private float frequency = 1f;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //spin object
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

        //float
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = tempPos;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            switch (pickUpType)
            {
                case TypesOfPickUps.Timer:
                    Debug.Log("Added time");
                    Timer.timer += addedTime;
                    break;
                case TypesOfPickUps.Multiplyer:
                    Debug.Log("Added multiplyer");
                    break;
            }
            Destroy(this.gameObject);
        }
    }
}
