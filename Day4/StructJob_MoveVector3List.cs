using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public struct StructJob_MoveVector3List : IJobParallelFor
{

    public NativeArray<Vector3> m_positions;
    public NativeArray<Quaternion> m_rotation;

    public float m_speed;
    public float m_timeDelta;
    public void Execute(int index)
    {
        Vector3 position = m_positions[index];
        Quaternion rotation = m_rotation[index];

        Vector3 dir = rotation * Vector3.forward;
        position = position + dir * m_speed * m_timeDelta;

        m_positions[index] = position;
        m_rotation[index] = rotation;
    }
}


