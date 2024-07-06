using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone8x8x8GuidTagMono : MonoBehaviour
{
    [Tooltip("Use to ban or load specific race piece")]
    public string m_guid;

    [ContextMenu("Reload new GUID")]
    public void ReloadNewGUID()
    {
        m_guid = System.Guid.NewGuid().ToString();
    }
    public void Reset()
    {
        ReloadNewGUID();
    }
}
