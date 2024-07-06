using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

public class MoveVector3WithJobsMono : MonoBehaviour
{
    public Transform[] m_whatToMove;
    public NativeArray<Vector3> m_positions;
    public NativeArray<Quaternion> m_rotation;

    public void Start()
    {
        m_positions = new NativeArray<Vector3>(m_whatToMove.Length, Allocator.Persistent);
        m_rotation = new NativeArray<Quaternion>(m_whatToMove.Length, Allocator.Persistent);
        FetchTransformInfo();
    }
    private void FetchTransformInfo()
    {
        for (int i = 0; i < m_whatToMove.Length; i++)
        {
            m_positions[i] = m_whatToMove[i].position;
            m_rotation[i] = m_whatToMove[i].rotation;
        }
    }
    public float m_moveSpeed = 1f;

    private void Update()
    {
        StructJob_MoveVector3List job = new StructJob_MoveVector3List();
        job.m_positions = m_positions;
        job.m_rotation = m_rotation;
        job.m_speed = m_moveSpeed;
        job.m_timeDelta = Time.deltaTime;
        JobHandle jobHandle = job.Schedule(m_positions.Length, 64);
        jobHandle.Complete();
        UpdateTransformInfo();

    }

    private void UpdateTransformInfo()
    {
        for (int i = 0; i < m_whatToMove.Length; i++)
        {
            m_whatToMove[i].position = m_positions[i];
            m_whatToMove[i].rotation = m_rotation[i];
        }
    }
}


