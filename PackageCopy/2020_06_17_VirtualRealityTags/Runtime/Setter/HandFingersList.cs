using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandFingersList : MonoBehaviour, I_StaticFacadeSetter
{
    public SideType m_sideType;
    public Transform m_wrist;
    public FingerAnchorsList m_pinky;
    public FingerAnchorsList m_ring;
    public FingerAnchorsList m_middle;
    public FingerAnchorsList m_index;
    public FingerAnchorsList m_thumb;
    public void Awake()
    {
        OverrideStaticFacadeWithInfo();
    }

    public void OverrideStaticFacadeWithInfo()
    {
        VirtualRealityTags.SetHandWrist(m_sideType, m_wrist);
        PushToFacade(m_pinky, FingerTags.Pinky);
        PushToFacade(m_ring, FingerTags.Ring);
        PushToFacade(m_middle, FingerTags.Middle);
        PushToFacade(m_index, FingerTags.Index);
        PushToFacade(m_thumb, FingerTags.Thumb);
    }

    private void PushToFacade(FingerAnchorsList finger, FingerTags type)
    {
        for (int i = 0; i < finger.GetCount(); i++)
        {
            VirtualRealityTags.SetFingerBoneAnchorFromLeaf(m_sideType, type, i, finger.GetFromLeaf(i));
            VirtualRealityTags.SetFingerBoneAnchorFromRoot(m_sideType, type, i, finger.GetFromRoot(i));
        }
    }

    public FingerAnchorsList Get(FingerTags fingerType)
    {
        switch (fingerType)
        {
            case FingerTags.Pinky:return m_pinky;
            case FingerTags.Ring: return m_ring;
            case FingerTags.Middle: return m_middle;
            case FingerTags.Index: return m_index;
            case FingerTags.Thumb: return m_thumb;
            default:
                break;
        }
        return null;
    }

    public Transform GetWrist()
    {
        return m_wrist;
    }

   
}
