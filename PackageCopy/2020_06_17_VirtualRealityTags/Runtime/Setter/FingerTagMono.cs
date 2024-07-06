using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerTagMono : MonoBehaviour, I_StaticFacadeSetter
{
    public SideType m_handSide;
    public FingerTags m_fingerType;
    public Transform m_target;
    public void Awake()
    {
        OverrideStaticFacadeWithInfo();
    }

    public void OverrideStaticFacadeWithInfo()
    {
        VirtualRealityTags.SetFingerTip(m_handSide, m_fingerType, m_target);
    }

    private void Reset()
    {
        m_target = transform;
    }

}
