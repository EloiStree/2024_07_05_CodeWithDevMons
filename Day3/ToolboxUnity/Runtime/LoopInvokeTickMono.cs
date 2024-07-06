using UnityEngine;
using UnityEngine.Events;

public class LoopInvokeTickMono : MonoBehaviour
{
    public float m_startAfter = 1.0f;
    public float m_interval = 1.0f;
    public UnityEvent m_onTick;

    void Start()
    {
        InvokeRepeating("OnTick", m_startAfter, m_interval);
    }

    public void OnTick()
    {
        m_onTick.Invoke();
    }

}