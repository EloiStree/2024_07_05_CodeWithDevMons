using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DFlagMono_RootTag : MonoBehaviour
{
    [Tooltip("GUID to idenitfy in prefab what type of flag step is this prefab")]
    public string m_flagTypeGuid;


    public string GetGuid() { return m_flagTypeGuid; }

    
    [ContextMenu("Generate New GUID")]
    public void GenerateNewGuid() {
        m_flagTypeGuid = System.Guid.NewGuid().ToString();
    }

    private void Reset()
    {
        GenerateNewGuid();
    }
}
