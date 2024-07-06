using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TDD_FollowSwitcher : MonoBehaviour
{
    public float m_timeBetweenChange=2;
    public FollowVirtualRealityTagAbstract followVR;
    public FollowFingerAnchorAbstract followFinger;

    void Start()
    {
        InvokeRepeating("ChangeTarget",0, m_timeBetweenChange);
    }

    public void ChangeTarget() {

        followFinger.SwitchTo(UnityEngine.Random.value>0.5f? SideType.Left: SideType.Right, GetRandomFinger(), UnityEngine.Random.Range(0,4));
        followVR.SwitchTo(GetRandomClassic());
    }
    

    public List<FingerTags> GetFingers()
    {
       return Enum.GetValues(typeof(FingerTags)).Cast<FingerTags>().ToList();
    }
    public List<VirtualRealityClassicTags> GetClassic()
    {
       return  Enum.GetValues(typeof(VirtualRealityClassicTags)).Cast<VirtualRealityClassicTags>().ToList();
    }
    public FingerTags GetRandomFinger()
    {
        List<FingerTags> l = GetFingers();
        return l[UnityEngine.Random.Range(0, l.Count)];
    }
    public VirtualRealityClassicTags GetRandomClassic()
    {
        List<VirtualRealityClassicTags> l = GetClassic();
        return l[UnityEngine.Random.Range(0, l.Count)];
    }
}
