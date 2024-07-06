using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DFlagMono_GlowingStickSize : MonoBehaviour
{
    public float m_sizeInMeter = 1;
    public float m_radiusMultiplication = 1;
    public Transform m_top;
    public Transform m_down;
    public Transform m_center;

    public Vector3 m_rotationTopAdjustment= new Vector3(180,0,0);
    //public float m_meshOffsetCorrection = 0.016f;

    private void Awake()
    {

        RefreshSize();
    }
    private void OnValidate()
    {
        RefreshSize();
    }

    public void SetSize(float sizeInMeter) {
        m_sizeInMeter = sizeInMeter;
        RefreshSize();
    }
    private void RefreshSize()
    {
        m_top.position = m_center.position + (m_center.up * ((m_sizeInMeter / 2f)));//-m_center.up * m_meshOffsetCorrection;
        m_down.position = m_center.position - (m_center.up * ((m_sizeInMeter / 2f)));//- m_center.up * m_meshOffsetCorrection;
        m_top.localScale = Vector3.one * m_radiusMultiplication;
        m_down.localScale = Vector3.one * m_radiusMultiplication;
        m_top.rotation = m_center.rotation;
        m_down.rotation = m_center.rotation;
        m_down.Rotate(m_rotationTopAdjustment, Space.Self);
    }

    private void Reset()
    {
        List<Transform> t = new List<Transform>();
        m_center = transform;
        GetComponentsInChildren(t);
        List<Transform> b0 = t.Where(k => k.name == "Top").ToList();
        if (b0.Count > 0)
            m_top = b0[0];
        List<Transform> b1 = t.Where(k => k.name == "Down").ToList();
        if (b1.Count > 0)
            m_down = b1[0];
        //List<Transform> bc = t.Where(k => k.name == "Armature Glowing Stick").ToList();
        //if (bc.Count > 0)
        //    m_center = bc[0];

        
        RefreshSize();
    }
}
