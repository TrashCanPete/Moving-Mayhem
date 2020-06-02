using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInCharacter : MonoBehaviour
{
    public Transform playerStart;
    public Vector3 playertransformPosition;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    // Start is called before the first frame update
    void Start()
    {
        switch (CharacterSelectCam.characterIndex)
        {
            case 2:
                Instantiate(player1, playerStart);
                break;
            case 1:
                Instantiate(player2, playerStart);
                break;
            default:
                Instantiate(player1, playerStart);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
