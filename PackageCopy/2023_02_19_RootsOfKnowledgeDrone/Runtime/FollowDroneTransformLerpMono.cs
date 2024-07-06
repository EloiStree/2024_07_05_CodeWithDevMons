using UnityEngine;

public class FollowDroneTransformLerpMono : MonoBehaviour
{
    public Transform m_target;
    public Transform m_whatToMove;
    public float m_lerpSpeedMove = 0.2f;
    public float m_lerpSpeedRotate = 0.65f;

    public bool m_useLateUpdate;
    void Update()
    {
        if (!m_useLateUpdate)
            UpdateLerp();
    }
    void LateUpdate()
    {
        if (m_useLateUpdate)
            UpdateLerp();
    }

    private void UpdateLerp()
    {
        if (m_target != null && m_whatToMove != null)
        {
            m_whatToMove.position = Vector3.Lerp(m_whatToMove.position, m_target.position, m_lerpSpeedMove);
            m_whatToMove.rotation = Quaternion.Lerp(m_whatToMove.rotation, m_target.rotation, m_lerpSpeedRotate);
        }
    }
}
