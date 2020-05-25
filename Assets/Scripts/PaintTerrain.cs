using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PaintTerrain : MonoBehaviour
{
    [HideInInspector] public Terrain t;
    [HideInInspector] public GameObject currentTerrain;
    [SerializeField] float paintingDist;
    const int size = 7;
    const float threshhold = 0.75f;
    float[,,] mainMap = new float[size, size, 2];
    //float[] textureValues = new float[2];

    private void Start()
    {
        StartCoroutine(Check());
    }
    private IEnumerator Check()
    {
        while (enabled)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -transform.up, out hit, paintingDist))
            {
                if (hit.collider.tag == "Grass")
                {
                    if (hit.transform.gameObject != currentTerrain)
                    {
                        if (hit.transform.gameObject.GetComponent<Terrain>() != null)
                        {
                           GetTerrain(hit.transform.gameObject);
                        }
                    }
                    Paint(transform.position,mainMap);
                }
            }
            yield return new WaitForSeconds(1 /60);
        }
    }
    void GetTerrain(GameObject obj)
    {
        Debug.Log("New Terrain here");
        t = obj.GetComponent<Terrain>();
        float[,,] map = new float[size, size, t.terrainData.terrainLayers.Length];
        map = SetMap(map);
        currentTerrain = obj;
        mainMap = map;
    }
    float [,,] SetMap(float[,,] map)
    {
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                map[x, y, 0] = 1;
                map[x, y, 1] = 0;
            }
        }
        return map;
    }
    
    void Paint(Vector3 position,float[,,] map)
    {
        Vector3 checkingPos = GetPos(transform.position+transform.forward*1.5f);
        bool[] paintAndScore =CheckTexture(checkingPos);
        Vector3 pos = GetPos(position);
        if(paintAndScore[1])
            Score.points++;
        if (paintAndScore[0])
            t.terrainData.SetAlphamaps((int)pos.x, (int)pos.z, map);
    }
    Vector3 GetPos(Vector3 position)
    {
        Vector3 pos = (position+new Vector3(-0.5f,0,-0.5f)) - t.GetPosition();
        pos.x = pos.x / t.terrainData.size.x;
        pos.z = pos.z / t.terrainData.size.z;
        pos.x = pos.x * t.terrainData.alphamapWidth;
        pos.z = pos.z * t.terrainData.alphamapHeight;
        pos.x = Mathf.Clamp(pos.x, 0, t.terrainData.alphamapWidth-size);
        pos.z = Mathf.Clamp(pos.z, 0, t.terrainData.alphamapHeight-size);
        return pos;
    }
    bool[] CheckTexture(Vector3 position)
    {
        float[,,] aMap = t.terrainData.GetAlphamaps((int)position.x, (int)position.z, 1, 1);
        float[] textureValues = new float[aMap.GetLength(2)];
        for (int i=0;  i < aMap.GetLength(2); i++)
        {
            textureValues[i] = aMap[0, 0, i];

        }
        bool paint = false;
        bool score = false;
        if (textureValues[1] >threshhold)
        {
            score = true;
        }
        if(textureValues[1] > threshhold|| textureValues[0] > threshhold)
        {
            paint = true;
        }
        bool[] paintAndScore = new bool[] { paint, score };
        return paintAndScore;
    }
}