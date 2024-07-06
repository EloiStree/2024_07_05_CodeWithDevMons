using Eloi.WatchAndDate;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGroupTransformMono : MonoBehaviour
{

    public Transform[] m_whatToMove;
    public float m_speed = 1.0f;

    public WatchAndDateTimeActionResult m_watchAndDate;
    public void Update()
    {
        m_watchAndDate.StartCounting();
        for (int i = 0; i < m_whatToMove.Length; i++)
        {
            if(m_whatToMove[i] != null)
            m_whatToMove[i].Translate(Vector3.forward * m_speed * Time.deltaTime);
        }
        m_watchAndDate.StopCounting();
    }

}
