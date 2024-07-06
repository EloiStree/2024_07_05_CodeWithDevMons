using Eloi.WatchAndDate;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTransformMono : MonoBehaviour
{
    public Transform m_whatToMove;
    public WatchAndDateTimeActionResult m_watchAndDate;
    public float m_speed = 1.0f;
    private void Reset()
    {
        m_whatToMove = transform; 
    }

    public void Update()
    {
        m_watchAndDate.StartCounting();
        m_whatToMove.Translate(Vector3.forward* m_speed * Time.deltaTime);
        m_watchAndDate.StopCounting();
    }
}
