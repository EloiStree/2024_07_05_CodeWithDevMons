using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Race8x8x8ResourceLoaderMono : MonoBehaviour
{
    public string m_folderName="8x8x8";
    public UnityEvent<GameObject[]> m_onAllPrefabFound;

    [Header("Loaded")]
    public GameObject[] m_prefabsFound;
    public List<GameObject> m_tagCrossroads = new List<GameObject>();
    public List<GameObject> m_tagLine = new List<GameObject>();
    public List<GameObject> m_tagCorner = new List<GameObject>();
    public List<GameObject> m_tagSquareIndex = new List<GameObject>();
    public List<GameObject> m_tagStart = new List<GameObject>();
    public List<GameObject> m_tagEnd = new List<GameObject>();

    [ContextMenu("Load level")]
    public void LoadLevels()
    {
        // Load all GameObjects (prefabs) from the "8x8x8" folder within Resources
        m_prefabsFound = Resources.LoadAll<GameObject>("8x8x8");
        m_prefabsFound = m_prefabsFound.Where(k=> k.GetComponent<Drone8x8x8Mono_WhatToMove>() != null && k.GetComponent<Drone8x8x8GuidTagMono>() != null).ToArray();

        foreach (GameObject prefab in m_prefabsFound)
        {
            if (prefab.GetComponent<Drone8x8x8Tag_Crossroads>() != null)
            {
                m_tagCrossroads.Add(prefab);
            }
             if (prefab.GetComponent<Drone8x8x8Tag_Line>() != null)
            {
                m_tagLine.Add(prefab);
            }
             if (prefab.GetComponent<Drone8x8x8Tag_Corner>() != null)
            {
                m_tagCorner.Add(prefab);
            }
             if (prefab.GetComponent<Drone8x8x8Tag_SquareIndex>() != null)
            {
                m_tagSquareIndex.Add(prefab);
            }
             if (prefab.GetComponent<Drone8x8x8Tag_StartRace>() != null)
            {
                m_tagStart.Add(prefab);
            }
             if (prefab.GetComponent<Drone8x8x8Tag_EndRace>() != null)
            {
                m_tagEnd.Add(prefab);
            }

            m_onAllPrefabFound.Invoke(m_prefabsFound);
        }




    }
}
