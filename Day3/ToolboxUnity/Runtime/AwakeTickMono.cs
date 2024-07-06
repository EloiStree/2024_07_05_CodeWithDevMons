using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AwakeTickMono : MonoBehaviour
{
    public UnityEvent m_onAwake;
    private void Awake()
    {
        m_onAwake.Invoke();
    }
}
