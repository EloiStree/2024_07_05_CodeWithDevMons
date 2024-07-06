using Eloi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoMoveDroneFalgMono : MonoBehaviour
{

    public Transform m_moveTransform;
    public Transform m_flagTransform;
    public MoveCubeAsDroneMono m_moveDroneScript;
    public Vector3 m_localDirectionOfFlag;

    public float m_angleHorizontal = 0;

    public bool m_stopMoving;

    public void Awake()
    {
        if(!m_stopMoving)
        m_moveDroneScript.SetMoveForward(0.1f);
    }
    public void Update()
    {
        Vector3 pDrone = m_moveTransform.position;
        Quaternion qDrone = m_moveTransform.rotation;
        Vector3 pFlag = m_flagTransform.position;

        Debug.DrawLine(m_moveTransform.position, m_flagTransform.position);
        ToolboxRelocationUtility.GetWorldToLocal_Point(pFlag, pDrone, qDrone, out m_localDirectionOfFlag);
        Debug.DrawLine(Vector3.zero, m_localDirectionOfFlag, Color.yellow);

        if (!m_stopMoving){ 
            bool isFlagLeft = m_localDirectionOfFlag.x < 0f;
            if (isFlagLeft)
                m_moveDroneScript.SetRotateLeftRigh(-1);
            else m_moveDroneScript.SetRotateLeftRigh(1);

            bool isFlagUp = m_localDirectionOfFlag.y > 0f;
            if (isFlagUp)
                m_moveDroneScript.SetMoveUp(1);
            else m_moveDroneScript.SetMoveUp(-1);
        }

        Vector3 flagAngleHorizontal = m_localDirectionOfFlag;
        flagAngleHorizontal.y = 0;
        m_angleHorizontal = Vector3.Angle(Vector3.forward, flagAngleHorizontal);

    }





}
