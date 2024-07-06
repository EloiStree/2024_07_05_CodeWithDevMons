using Eloi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class ALARMANGLEMono : MonoBehaviour
{
    public UnityEvent<bool> m_onPlayerInZone;
    public float m_angleFromCenterToDetect = 30;
    public float m_distanceVision = 10;

    public Transform m_soldat;
    public Transform m_player;


    public bool m_isPlayerInZone;

    void Start()
    {
        
    }

    public Vector3 localPositionPlayer;
    public float playerAngle;
    public float m_playerDistance;
    public bool m_isInRange;
    void Update()
    {
        Vector3 forward = m_soldat.transform.forward;

        Quaternion angleSoldatViewRight = Quaternion.Euler(0, m_angleFromCenterToDetect, 0);
        Vector3 right = angleSoldatViewRight * forward;
        Quaternion angleSoldatViewLeft = Quaternion.Euler(0, -m_angleFromCenterToDetect, 0);
        Vector3 left = angleSoldatViewLeft * forward;

        Debug.DrawLine(m_soldat.position, m_soldat.position + left * m_distanceVision, Color.yellow);
        Debug.DrawLine(m_soldat.position, m_soldat.position + right * m_distanceVision, Color.yellow);
        Debug.DrawLine(m_soldat.position, m_soldat.position + forward * m_distanceVision, Color.red);

        Vector3 pSoldat = m_soldat.position;
        Quaternion qSoldat = m_soldat.rotation;
        Vector3 pPlayer = m_player.position;

        ToolboxRelocationUtility.GetWorldToLocal_Point(pPlayer, pSoldat, qSoldat, out localPositionPlayer);
        localPositionPlayer.y = 0;
        playerAngle = Vector3.Angle(Vector3.forward, localPositionPlayer);

        bool isPlayerinViewLocal = playerAngle < m_angleFromCenterToDetect;

        bool isInZoneChanged= m_isPlayerInZone != isPlayerinViewLocal;
        if (isInZoneChanged)
        {
            m_isPlayerInZone = isPlayerinViewLocal;
            m_onPlayerInZone.Invoke(m_isPlayerInZone);
        }

        m_playerDistance = (pPlayer - pSoldat).magnitude;
        m_playerDistance = Vector3.Distance(pPlayer, pSoldat);
        m_isInRange = m_playerDistance < m_distanceVision;



    }
}
