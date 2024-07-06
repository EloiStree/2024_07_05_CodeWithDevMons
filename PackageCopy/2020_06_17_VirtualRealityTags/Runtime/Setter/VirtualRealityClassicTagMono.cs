using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualRealityClassicTagMono : MonoBehaviour, I_StaticFacadeSetter
{
    public VirtualRealityClassicTags m_tagType;
    public Transform m_target;
    public void Awake()
    {
        OverrideStaticFacadeWithInfo();
    }

    public void OverrideStaticFacadeWithInfo()
    {
        VirtualRealityTags.SetClassicVrTag(m_tagType, m_target);
    }

    private void Reset()
    {
        m_target = transform;
    }
}

