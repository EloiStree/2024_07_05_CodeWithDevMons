using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMono_DrawHorizontalLineAngle : MonoBehaviour
{

    public Vector3 m_euleurRotation;

    public Transform m_whatToRotate;
    public float m_distanceDraw = 2;
    public Color m_color;

    public float m_angle = 82;

    void Update()
    {

        Vector3 frontPlayer = m_whatToRotate.forward;
        Debug.DrawLine(m_whatToRotate.position, m_whatToRotate.position + frontPlayer * m_distanceDraw, m_color);

        Quaternion eulerRotateRight = Quaternion.Euler(0, m_angle, 0);
        Quaternion rotation = m_whatToRotate.rotation* eulerRotateRight;
        Vector3 frontRightDraw = rotation * Vector3.forward;
        Debug.DrawLine(m_whatToRotate.position, m_whatToRotate.position + frontRightDraw * m_distanceDraw, m_color/2f);


    }
}
