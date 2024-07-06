using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DebugDroneSquareMono : MonoBehaviour
{
    public UnityEvent<bool> m_onSetActive;


    [ContextMenu("Display")]
    public void Display()
    {
        SetActive(true);
    }

    [ContextMenu("Hide")]
    public void Hide()
    {
        SetActive(true);
    }


    public void SetActive(bool value)
    {
        m_onSetActive.Invoke(value);
    }
}
