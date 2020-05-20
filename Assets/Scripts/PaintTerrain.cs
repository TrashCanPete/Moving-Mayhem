using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintTerrain : MonoBehaviour
{
    [SerializeField] LayerMask paintLayers;
    public Terrain t;
    public GameObject currentTerrain;
    [SerializeField] float paintingDist;
    const int size = 7;
    float[,,] map = new float[size, size, 2];
    public Vector3 pos;
    float[] textureValues = new float[2];

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
        StartCoroutine(Check());
    }
    private IEnumerator Check()
    {
        while (enabled)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -transform.up, out hit, paintingDist, paintLayers))
            {
                if (hit.collider.tag == "Grass")
                {
                    if (hit.transform.gameObject != currentTerrain)
                    {
                        if (hit.transform.gameObject.GetComponent<Terrain>() != null)
                        {
                            Debug.Log("New Terrain here");
                            t = hit.transform.gameObject.GetComponent<Terrain>();
                            currentTerrain = hit.transform.gameObject;
                        }
                    }
                    GetPos();
                    Paint();
                }
            }
            yield return new WaitForSeconds(1 /60);
        }
    }
    
    void Paint()
    {
        CheckTexture();
        if (textureValues[0] == 0)
        {
            Score.points++;
        }
        t.terrainData.SetAlphamaps((int)pos.x, (int)pos.z, map);
    }
    void GetPos()
    {
        pos = (transform.position+new Vector3(-0.5f,0,-0.5f)) - t.GetPosition();
        pos.x = pos.x / t.terrainData.size.x;
        pos.z = pos.z / t.terrainData.size.z;
        pos.x = pos.x * t.terrainData.alphamapWidth;
        pos.z = pos.z * t.terrainData.alphamapHeight;
        pos.x = Mathf.Clamp(pos.x, 0, t.terrainData.alphamapWidth-size);
        pos.z = Mathf.Clamp(pos.z, 0, t.terrainData.alphamapHeight-size);
    }
    void CheckTexture()
    {
        float[,,] aMap = t.terrainData.GetAlphamaps((int)pos.x, (int)pos.z, 1, 1);
        textureValues[0] = aMap[0, 0, 0];
        textureValues[1] = aMap[0, 0, 1];
    }
}