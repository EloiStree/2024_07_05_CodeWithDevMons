using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

public class JobMoveTransformMono : MonoBehaviour
{
    public Transform[] m_whatToScale;
    [Range(-1f,1f)]
    public float m_scale = 1f;
    void Update()
    {
        TransformAccessArray transformAccessArray = new TransformAccessArray(m_whatToScale);
        StructJob_MoveTransform job = new StructJob_MoveTransform();
        job.m_scaleFactor = m_scale;
        job.m_timeDelta = Time.deltaTime;
        JobHandle jobHandle = job.Schedule(transformAccessArray);
        jobHandle.Complete();
        transformAccessArray.Dispose();
        
    }
}


