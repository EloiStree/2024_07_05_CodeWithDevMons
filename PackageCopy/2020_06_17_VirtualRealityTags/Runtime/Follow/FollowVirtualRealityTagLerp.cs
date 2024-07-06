using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class FollowVirtualRealityTagLerp : FollowVirtualRealityTagAbstract
{
    public bool m_usePosition=true;
    public float m_positionLerpSpeed=2f;

    public bool m_useRotation=true;
    public float m_rotationLerpSpeed=2f;

    public bool m_flyWeightLoad=true;

    void Update()
    {
        Transform t = GetTransform(!m_flyWeightLoad);
        if (t == null) 
            return;
        if(m_usePosition)
            m_affect.position = Vector3.Lerp(m_affect.position, t.position, Time.deltaTime * m_positionLerpSpeed);

        if (m_useRotation)
            m_affect.rotation = Quaternion.Lerp(m_affect.rotation, t.rotation, Time.deltaTime * m_rotationLerpSpeed);
    }

    
}
