using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTerrainTexture : MonoBehaviour
{

    public Transform playerTransform;
    public Terrain t;

    public int posX;
    public int posZ;
    public float[] textureValues;


    void ConvertPosition(Vector3 playerPosition)
    {
        Vector3 terrainPosition = playerPosition - t.transform.position;

        Vector3 mapPosition = new Vector3
            (terrainPosition.x / t.terrainData.size.x, 0,
            terrainPosition.z / t.terrainData.size.z);

        float xCoord = mapPosition.x * t.terrainData.alphamapWidth;
        float zCoord = mapPosition.z * t.terrainData.alphamapHeight;

        posX = (int)xCoord;
        posZ = (int)zCoord;
    }
}
