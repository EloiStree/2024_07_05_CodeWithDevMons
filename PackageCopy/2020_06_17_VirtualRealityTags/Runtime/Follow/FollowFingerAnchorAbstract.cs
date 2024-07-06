using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowFingerAnchorAbstract : MonoBehaviour
{

    public SideType m_sideType;
    public FingerTags m_toFollow;
    public int m_indexFromleaf;

    public Transform m_affect;
    Transform m_foundToFollow = null;
    public Transform GetTransform(bool useOverride)
    {

        if (m_foundToFollow == null || useOverride)
        {
            bool found;
            VirtualRealityTags.GetFingerBoneAnchorFromLeaf(m_sideType, m_toFollow, m_indexFromleaf, out found, out m_foundToFollow);
        }

        return m_foundToFollow;
    }

    public void SwitchTo(SideType sideType, FingerTags fingerTag, int index)
    {
        m_sideType = sideType;
        m_toFollow = fingerTag;
        m_indexFromleaf = index;
        GetTransform(true);
    }


    private void Reset()
    {
        m_affect = transform;
    }
}
