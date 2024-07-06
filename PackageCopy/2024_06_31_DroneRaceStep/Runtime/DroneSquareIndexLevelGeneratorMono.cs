using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSquareIndexLevelGeneratorMono : MonoBehaviour
{

    public GameObject[] m_prefabToUse;
    public Transform m_whereToCreateInstance;


    public List<GameObject> m_createdInstance= new List<GameObject>();
    public Dictionary<string,GameObject> m_claimIndex= new Dictionary<string, GameObject>();


    [ContextMenu("Destroy Level")]
    public void DestroyCreatedInstances()
    {
        for (int i = 0; i < m_createdInstance.Count; i++)
        {
            DestroyImmediate(m_createdInstance[i]);
        }
        m_createdInstance.Clear();
        m_claimIndex.Clear();
    }
    [ContextMenu("Reload Level")]
    public void ReloadLevel()
    {
        DestroyCreatedInstances();
        LoadLevel();
    }

    public void SetPrefab(GameObject[] prefab) { 
        
        m_prefabToUse = prefab;
    }

    [ContextMenu("Load Level")]
    public void LoadLevel() {

        List<GameObject> list = new List<GameObject>();
        list.AddRange(m_prefabToUse);
        Shuffle(list);
        foreach (GameObject prefab in m_prefabToUse)
        {
            Drone8x8x8Tag_SquareIndex index= prefab.GetComponent<Drone8x8x8Tag_SquareIndex>();
            if (index != null) {
                string id = index.m_indexLeftToRightX + "_" + index.m_indexBackToFrontZ;
                if(!m_claimIndex.ContainsKey(id)) {

                    GameObject instance = Instantiate(prefab);
                    m_createdInstance.Add(instance);
                    float x = index.m_indexLeftToRightX>0?
                        (4 + (index.m_indexLeftToRightX-1) * 8f):
                        (-4 + (index.m_indexLeftToRightX + 1) * 8f);
                    float z = index.m_indexBackToFrontZ>0?
                        (4 + (index.m_indexBackToFrontZ - 1) * 8f):
                        (-4 + (index.m_indexBackToFrontZ+1) * 8f);
                    instance.transform.position = new Vector3(x, 0, z);
                    instance.transform.parent = m_whereToCreateInstance;
                    instance.SetActive(true);
                }
            }
        }

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
