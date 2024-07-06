using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DroneSquareCornerLineGeneratorMono : MonoBehaviour
{


    public GameObject[] m_prefabToUse;
    public Transform m_whereToCreateInstance;

    public Loop8x8x8AnchorMono m_loopAnchor;
    public List<GameObject> m_createdInstance = new List<GameObject>();
    public List<GameObject> m_corners;
    public List<GameObject> m_lines;



    public void SetPrefab(GameObject[] prefab) { 
        m_prefabToUse = prefab;
    }

[ContextMenu("Destroy Level")]
public void DestroyCreatedInstances()
{
    for (int i = 0; i < m_createdInstance.Count; i++)
    {
        DestroyImmediate(m_createdInstance[i]);
    }
    m_createdInstance.Clear();
}
[ContextMenu("Reload Level")]
public void ReloadLevel()
{
    DestroyCreatedInstances();
    LoadLevel();
}

[ContextMenu("Load Level")]
public void LoadLevel()
{
         SortPrefab();

         Shuffle(m_corners);
         Shuffle(m_lines);

         GameObject [] pc = GetCorners();
         GameObject [] pl = GetLines();
         SetTransform(pc[0].transform ,m_loopAnchor.m_topRightCorner   ,90);
         SetTransform(pc[1].transform ,m_loopAnchor.m_downRightCorner  ,180);
         SetTransform(pc[2].transform ,m_loopAnchor.m_downLeftCorner   ,270);
         SetTransform(pc[3].transform ,m_loopAnchor.m_topLeftCorner    ,0);
         SetTransform(pl[0].transform ,m_loopAnchor.m_topRightLine     ,90);
         SetTransform(pl[1].transform ,m_loopAnchor.m_rightTopLine     ,180);
         SetTransform(pl[2].transform ,m_loopAnchor.m_rightDownLine    ,180);
         SetTransform(pl[3].transform ,m_loopAnchor.m_bottomRightLine  ,-90);
         SetTransform(pl[4].transform ,m_loopAnchor.m_bottomLeftLine   ,-90);
         SetTransform(pl[5].transform ,m_loopAnchor.m_leftDownLine     ,0);
         SetTransform(pl[6].transform ,m_loopAnchor.m_leftTopLine      ,0);
         SetTransform(pl[7].transform, m_loopAnchor.m_topLeftLine      ,90);
        

    }

    private void SetTransform(Transform toMove, Transform whereToMove, float rotation)
    {
        toMove.position = whereToMove.position;
        toMove.rotation = whereToMove.rotation;
        toMove.localScale = whereToMove.localScale;
        toMove.Rotate(0, rotation, 0);
    }

    private GameObject[] GetCorners()
    {
        GameObject[] corners = new GameObject[4];
        for (int i = 0; i < 4; i++) {
            corners[i] = GameObject.Instantiate( m_corners[i % m_corners.Count] );
            m_createdInstance.Add(corners[i]);
            corners[i].transform.SetParent(m_whereToCreateInstance);
        }
        return corners;
    }
    public GameObject[] GetLines()
    {
        GameObject[] lines = new GameObject[8];
        for (int i = 0; i < 8; i++)
        {
            lines[i] = GameObject.Instantiate( m_lines[i % m_lines.Count] );
            m_createdInstance.Add(lines[i]);
            lines[i].transform.SetParent(m_whereToCreateInstance);
        }
        return lines;
    }

    private void SortPrefab()
    {
        List<GameObject> corners = new List<GameObject>();
        List<GameObject> lines = new List<GameObject>();

        foreach (GameObject prefab in m_prefabToUse)
        {
            Drone8x8x8Tag_SquareIndex index = prefab.GetComponent<Drone8x8x8Tag_SquareIndex>();
            if (prefab.GetComponent<Drone8x8x8Tag_Corner>())
            {
                corners.Add(prefab);
            }
            if(prefab.GetComponent<Drone8x8x8Tag_Line>())
            {
                lines.Add(prefab);
            }
        }

        m_corners = corners.ToList();
        m_lines = lines.ToList();

    }

    private void Shuffle(List<GameObject> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            GameObject temp = list[i];
            int randomIndex = UnityEngine.Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
