using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowVirtualRealityTagDirect : FollowVirtualRealityTagAbstract
{
    public bool m_usePosition = true;
    public bool m_useRotation = true;

    void Update()
    {
        Transform t = GetTransform(false);
        if (t == null)
            return;
        if (m_usePosition)
            m_affect.position =  t.position;

        if (m_useRotation)
            m_affect.rotation =  t.rotation;
    }

}
