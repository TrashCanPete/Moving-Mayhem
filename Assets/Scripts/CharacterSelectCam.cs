using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectCam : MonoBehaviour
{
    //vector3 values for each character rotation
    //rotate between each rotation
    //index = x;
    //index % array.count to cycle between each availabe array
    //var array = array[index % array.count]
    //transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, turningRate * Time.deltaTime);
    [SerializeField]
    private GameObject[] characters;
    [SerializeField]
    private int index;


    // Start is called before the first frame update
    void Start()
    {
        index = 1;
    }

    // Update is called once per frame
    void Update()
    {



        var _index = index;

        while (index <= 0)
        {
            index += characters.Length;
        }
        var choice = characters[index % characters.Length];
        var currentRotation = transform.rotation;
        var goalRotation = Quaternion.LookRotation(choice.transform.position - transform.position);
        transform.rotation = Quaternion.Lerp(currentRotation, goalRotation, 0.1f);

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            index++;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            index--;
        }
    }
}
