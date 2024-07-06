using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDD_DrawEyesDirection : MonoBehaviour
{

    public Color m_color = new Color(1,0,0);
    public float m_drawDistance = 0.2f;
    public bool m_useLatency;
    public float m_latencyTime = 0.5f;

    Transform m_leftEye;
    Transform m_rightEye;

    void Update()
    {
        if (m_leftEye == null)
        {
            bool found;
            VirtualRealityTags.GetClassicVrTag(VirtualRealityClassicTags.EyeLeft, out found, out m_leftEye);
        }
        if (m_rightEye == null)
        {
            bool found;
            VirtualRealityTags.GetClassicVrTag(VirtualRealityClassicTags.EyeRight, out found, out m_rightEye);
        }

        if (m_leftEye != null)
        {
            DrawLineInDireciton(m_leftEye, Time.deltaTime);
            if (m_useLatency)
                DrawLineInDireciton(m_leftEye, m_latencyTime);

        }
        if (m_rightEye != null)
        {
            DrawLineInDireciton(m_rightEye, Time.deltaTime);
            if(m_useLatency)
                DrawLineInDireciton(m_rightEye, m_latencyTime);
        }


    }

    private void DrawLineInDireciton(Transform direction, float time)
    {
        Debug.DrawLine(direction.position, direction.position + direction.forward * m_drawDistance, m_color, time);
    }
}
