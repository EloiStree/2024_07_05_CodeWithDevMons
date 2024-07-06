using Unity.Burst;
using UnityEngine;
using UnityEngine.Jobs;

[BurstCompile]
public struct StructJob_MoveTransform: IJobParallelForTransform
{
    public float m_scaleFactor;
    public float m_timeDelta;
    public void Execute(int index, TransformAccess transform)
    {
        Vector3 dir = transform.rotation * Vector3.forward;
        transform.position = transform.position + (dir * m_scaleFactor * m_timeDelta); 
    }
}


