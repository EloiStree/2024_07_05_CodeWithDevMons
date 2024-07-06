using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  static class VirtualRealityTags 
{

    private static Dictionary<VirtualRealityClassicTags, Transform> m_virtualRealityTagsRegister = new Dictionary<VirtualRealityClassicTags, Transform>();
    private static Dictionary<string, Transform> m_fingerTipTagsRegister = new Dictionary<string, Transform>();
    private static Dictionary<string, Transform> m_fingerBoneFromLeafTagsRegister = new Dictionary<string, Transform>();
    private static Dictionary<string, Transform> m_fingerBoneFromRootTagsRegister = new Dictionary<string, Transform>();
    private static Transform m_virtualRealityRoot;
    private static Transform m_wristLeft;
    private static Transform m_wristRight;
    private static Transform m_controllerLeft;
    private static Transform m_controllerRight;


    public static Transform GetVirtualRealityRootAnchor() { return m_virtualRealityRoot; }
    public static void GetClassicVrTag(VirtualRealityClassicTags tag, out bool found, out Transform targetFound)
    {
        found = m_virtualRealityTagsRegister.ContainsKey(tag);
        if (found) {
            targetFound = m_virtualRealityTagsRegister[tag];
        }
        else
            targetFound = null;
    }
    public static void SetClassicVrTag(VirtualRealityClassicTags tagType, Transform target)
    {
        if (!m_virtualRealityTagsRegister.ContainsKey(tagType))
            m_virtualRealityTagsRegister.Add(tagType, target);
        else m_virtualRealityTagsRegister[tagType] = target;
    }


    public static void GetFingerTipOf(SideType handSide, FingerTags tag, out bool found, out Transform targetFound)
    {
        string id = GetAsId(handSide, tag);
        found = m_fingerTipTagsRegister.ContainsKey(id);
        if (found) {
            targetFound = m_fingerTipTagsRegister[id];
        }
        else
            targetFound = null;
    }

    public static void SetFingerTip(SideType handSide, FingerTags tagType, Transform target)
    {
        string id = GetAsId(handSide, tagType);
        if (!m_fingerTipTagsRegister.ContainsKey(id))
            m_fingerTipTagsRegister.Add(id, target);
        else m_fingerTipTagsRegister[id] = target;
    }
    private static string GetAsId(SideType handSide, FingerTags tag) { return handSide.ToString() + tag.ToString(); }


    public static void SetFingerBoneAnchorFromLeaf(SideType side, FingerTags tag, int index, Transform target)
    {
        string id = GetAsId(index, tag, side);
        if (!m_fingerBoneFromLeafTagsRegister.ContainsKey(id))
            m_fingerBoneFromLeafTagsRegister.Add(id, target);
        else m_fingerBoneFromLeafTagsRegister[id] = target;
    }
    public static void SetFingerBoneAnchorFromRoot(SideType side, FingerTags tag, int index, Transform target)
    {
        string id = GetAsId(index, tag, side);
        if (!m_fingerBoneFromRootTagsRegister.ContainsKey(id))
            m_fingerBoneFromRootTagsRegister.Add(id, target);
        else m_fingerBoneFromRootTagsRegister[id] = target;
    }
    public static void GetFingerBoneAnchorFromLeaf(SideType side,  FingerTags tag, int index, out bool found, out Transform targetFound)
    {
        string id = GetAsId(index, tag, side);
        found = m_fingerBoneFromLeafTagsRegister.ContainsKey(id);
        if (found)
        {
            targetFound = m_fingerBoneFromLeafTagsRegister[id];
        }
        else
            targetFound = null;
    }
    public static void GetFingerBoneAnchorFromRoot(SideType side, FingerTags tag, int index, out bool found, out Transform targetFound)
    {
        string id = GetAsId(index, tag, side);
        found = m_fingerBoneFromRootTagsRegister.ContainsKey(id);
        if (found)
        {
            targetFound = m_fingerBoneFromRootTagsRegister[id];
        }
        else 
            targetFound = null; 
    }
    private static string GetAsId(int index, FingerTags finger ,SideType side) { return side+finger.ToString()+index; }


    public static void GetHandWrist(SideType side, out bool found, out Transform targetFound)
    {
        if (side == SideType.Left)
        {
            targetFound = m_wristLeft;
            found = m_wristLeft != null;
        }
        else
        {
            targetFound = m_wristRight;
            found = m_wristRight != null;
        }

    }
    public static void SetHandWrist(SideType side, Transform target) {
        if (side == SideType.Left)
        {
             m_wristLeft= target;
        }
        else
        {
            m_wristRight = target;
        }

    }
    public static void GetController(SideType side, out bool found, out Transform targetFound)
    {
        if (side == SideType.Left)
        {
            targetFound = m_controllerLeft;
            found = m_controllerLeft != null;
        }
        else
        {
            targetFound = m_controllerRight;
            found = m_controllerRight != null;
        }
    }
    public static void SetController(SideType side, Transform target)
    {
        if (side == SideType.Left)
        {
            m_controllerLeft = target;
        }
        else
        {
            m_controllerRight = target;
        }

    }

}


public interface I_StaticFacadeSetter
{
     void OverrideStaticFacadeWithInfo();
}