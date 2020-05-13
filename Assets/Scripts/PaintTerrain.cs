using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintTerrain : MonoBehaviour
{
    [SerializeField] Terrain t;
    const int size = 7;
    float[,,] map = new float[size, size, 2];
    private void Start()
    {
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                map[x, y, 0] = 1;
                map[x, y, 1] = 0;
            }
        }

        /*  for (int y = 0; y < t.terrainData.alphamapHeight; y++)
          {
              for (int x = 0; x < t.terrainData.alphamapWidth; x++)
              {
                  map[x, y, 0] = 1;
                  map[x, y, 1] = 0;
              }
          }*/
        StartCoroutine(Paint());
    }
     private IEnumerator Paint()
    {
        while (enabled)
        {
            Vector3 pos = transform.position - t.GetPosition();
            pos.x = pos.x / t.terrainData.size.x;
            pos.z = pos.z / t.terrainData.size.z;

            pos.x = pos.x * t.terrainData.alphamapWidth;
            pos.z = pos.z * t.terrainData.alphamapHeight;

            t.terrainData.SetAlphamaps((int)pos.x, (int)pos.z, map);
            yield return new WaitForSeconds(1 / 120);
        }
    }
}