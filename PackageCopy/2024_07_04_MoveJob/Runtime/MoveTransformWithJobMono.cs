using Eloi.WatchAndDate;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.UIElements;

public class MoveTransformWithJobMono : MonoBehaviour
{
    public Transform[] m_whatToMove;


    public float m_speed = 1f;


    public WatchAndDateTimeActionResult m_watchAndDate;
    public void Update()
    {
        m_watchAndDate.StartCounting();
        TransformAccessArray transformAccessArray = new TransformAccessArray(m_whatToMove);

        STRUCT_MoveTransformWithJob move = new STRUCT_MoveTransformWithJob();
        move.m_speed = m_speed;
        move.m_deltaTime= Time.deltaTime;
        move.Schedule(transformAccessArray).Complete();
        m_watchAndDate.StopCounting();
    }
}

[BurstCompile]
public struct STRUCT_MoveTransformWithJob : IJobParallelForTransform
{
    public float m_speed;
    public float m_deltaTime;
    public void Execute(int index, TransformAccess transform)
    {
        Vector3 forward = transform.rotation * Vector3.forward;
        transform.position = transform.position + forward * m_speed* m_deltaTime;
    }
}
