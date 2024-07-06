using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class QuadCameraForwardMono : MonoBehaviour
{
    public Camera m_camera;
    public Transform m_whatToMove;
    public void OnValidate()
    {
        Refresh();
    }
    public void Update()
    {
        Refresh();
    }

    public float m_rotationAdjustment = 180;
    [ContextMenu("Refresh")]
    private void Refresh()
    {
        m_camera = Camera.main;
        if(m_camera==null)
        {
            return;
        }
        m_whatToMove.forward = -m_camera.transform.forward;
        m_whatToMove.Rotate(0, m_rotationAdjustment, 0, Space.Self);
        m_whatToMove.rotation = m_camera.transform.rotation*Quaternion.Euler(0, m_rotationAdjustment, 0);
    }
    private void Reset()
    {
        m_whatToMove = transform;
        m_camera = Camera.main;
    }
}
