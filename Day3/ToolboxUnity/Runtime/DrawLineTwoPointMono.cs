using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLineTwoPointMono : MonoBehaviour
{

    public Transform m_from;
    public Transform m_to;
    public Color m_color;
    void Update()
    {
        Debug.DrawLine(m_from.position, m_to.position, m_color);
    }
}
