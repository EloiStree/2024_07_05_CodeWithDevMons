using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerAnchor : MonoBehaviour, I_StaticFacadeSetter
{

    public SideType m_sideType;
    public Transform m_controller;

    public void Awake()
    {
        OverrideStaticFacadeWithInfo();
    }

    public void OverrideStaticFacadeWithInfo()
    {
        VirtualRealityTags.SetController(m_sideType, m_controller);
    }

    private void Reset()
    {
        m_controller = transform;
    }

}
