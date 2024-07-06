using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawXYZLineMono : MonoBehaviour
{
    public Transform m_target;

    public float m_drawTime = 0.1f;
    public float m_drawDistance = 0.2f;

    void Update()
    {
        RefreshLine();
    }
    private void RefreshLine()
    {
        if (m_drawTime <= 0)
            RefreshLine(Time.deltaTime);
        else 
            RefreshLine(m_drawTime);
    }
    private void RefreshLine(float timeDraw)
    {
        Debug.DrawLine(m_target.position, m_target.position + m_target.right * m_drawDistance, Color.red, timeDraw);
        Debug.DrawLine(m_target.position, m_target.position + m_target.up * m_drawDistance, Color.green, timeDraw);
        Debug.DrawLine(m_target.position, m_target.position + m_target.forward * m_drawDistance, Color.blue, timeDraw);
    }

    private void Reset()
    {
        m_target = this.transform;
    
    }

    [ContextMenu("Display Lines for 10 seconds")]
    public void DisplayLineInEdior() {

        RefreshLine(10);
    }

}
