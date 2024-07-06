using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectWithHandMono : MonoBehaviour
{

    public Transform m_rootHandAnchor;
    public Transform m_handLeftAnchor;
    public Transform m_handRightAnchor;
    public Transform m_handCenterAnchor;


    public float m_pitchX;
    public float m_yawY;
    public float m_rollZ;


    public Vector3 m_handLeftRelocateZero;
    public Vector3 m_handCenterRelocateZero;
    public Vector3 m_handRightRelocateZero;

    public Vector3 m_handLeftRelocateZeroKeepRotation;
    public Vector3 m_handCenterRelocateZeroKeepRotation;
    public Vector3 m_handRightRelocateZeroKeepRotation;

    public Quaternion m_rootRotationAdjustment;

    public static void GetWorldToLocal_Point(in Vector3 worldPosition, in Vector3 positionReference, in Quaternion rotationReference, out Vector3 localPosition) =>
          localPosition = Quaternion.Inverse(rotationReference) * (worldPosition - positionReference);



    void Update()
    {

        Debug.DrawLine(m_handLeftAnchor.position, m_handRightAnchor.position, Color.red);
        Debug.DrawLine(m_handRightAnchor.position, m_handCenterAnchor.position, Color.green);
        Debug.DrawLine(m_handCenterAnchor.position, m_handLeftAnchor.position, Color.blue);




        Vector3 centerLeftRight = (m_handLeftAnchor.position + m_handRightAnchor.position) / 2;
        Vector3 dirForward = m_handCenterAnchor.position - centerLeftRight;
        Vector3 dirLeftRight = m_handRightAnchor.position - m_handLeftAnchor.position;

        Debug.DrawLine(centerLeftRight, centerLeftRight, Color.blue);
        Debug.DrawLine(centerLeftRight, centerLeftRight+ dirForward, Color.blue);

        Vector3 dirUp =  Vector3.Cross(dirForward, dirLeftRight);
        Vector3 upPoint= centerLeftRight + dirUp;
        Debug.DrawLine(centerLeftRight, centerLeftRight+ upPoint, Color.green);

        Quaternion forward = Quaternion.LookRotation(dirForward, Vector3.up);

        Debug.DrawLine(centerLeftRight, centerLeftRight + (forward * Vector3.forward));

        Vector3 dirRight = Vector3.Cross(dirForward, dirUp);
        Debug.DrawLine(centerLeftRight, centerLeftRight + (-dirRight), Color.red);

       
        GetWorldToLocal_Point(m_handLeftAnchor.position, m_rootHandAnchor.position, m_rootHandAnchor.rotation, out m_handLeftRelocateZero);
        GetWorldToLocal_Point(m_handCenterAnchor.position, m_rootHandAnchor.position, m_rootHandAnchor.rotation, out m_handCenterRelocateZero);
        GetWorldToLocal_Point(m_handRightAnchor.position, m_rootHandAnchor.position, m_rootHandAnchor.rotation, out m_handRightRelocateZero);

        Debug.DrawLine(m_handLeftRelocateZero, m_handCenterRelocateZero);

        Debug.DrawLine(m_handLeftRelocateZero, m_handRightRelocateZero);

        Debug.DrawLine(m_handRightRelocateZero, m_handCenterRelocateZero);


        Debug.DrawLine(Vector3.zero, Vector3.forward, Color.red);
        Debug.DrawLine(Vector3.zero, Vector3.right, Color.red);
        Debug.DrawLine(Vector3.zero, Vector3.up , Color.green);
    }
}
