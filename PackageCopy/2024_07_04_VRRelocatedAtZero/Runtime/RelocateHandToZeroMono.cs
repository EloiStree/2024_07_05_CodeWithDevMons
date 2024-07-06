
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelocateHandToZeroMono : MonoBehaviour
{
    
    [Header("Source")]
    public Transform m_playerHead;
    public Transform m_playerLeftHand;
    public Transform m_playerRightHand;

    [Header("Relocated debug")]
    public Transform m_playerHeadRelocated;
    public Transform m_playerLeftHandRelocated;
    public Transform m_playerRightHandRelocated;


    public float m_handDownDistance = 0.5f;


    [Header("World to Cartesian")]
    public Vector3 m_cartesianCenter;
    public Vector3 m_handLeftStart;
    public Vector3 m_handRightStart;
    public Vector3 m_handMiddle;
    public Vector3 m_handMiddleFlatY;
    public Vector3 m_cartersianForwardFlatDir;

    [Header("Cartesian World Player")]
    public Vector3 m_worldPlayerAxisPosition;
    public Quaternion m_worldPlayerAxisRotation;

    void Update()
    {

        m_cartesianCenter = m_playerHead.position - new Vector3(0, m_handDownDistance, 0);

        Debug.DrawLine(m_cartesianCenter, m_cartesianCenter + Vector3.up, Color.green);
        m_handLeftStart = m_playerLeftHand.position;
        m_handRightStart = m_playerRightHand.position;
        m_handMiddle = (m_handLeftStart + m_handRightStart) / 2;
        Debug.DrawLine(m_handLeftStart, m_handRightStart, Color.white);

        m_handMiddleFlatY = m_handMiddle;
        m_handMiddleFlatY.y = m_cartesianCenter.y;
        m_cartersianForwardFlatDir = m_handMiddleFlatY- m_cartesianCenter;

        Debug.DrawLine(m_cartesianCenter, m_handMiddleFlatY, Color.blue);
        Vector3 cartersianRightDir = Quaternion.Euler(0, 90, 0)* m_cartersianForwardFlatDir ;
        Debug.DrawLine(m_cartesianCenter, m_cartesianCenter + cartersianRightDir, Color.red);

        m_worldPlayerAxisPosition = m_cartesianCenter;
        m_worldPlayerAxisRotation = Quaternion.LookRotation(m_cartersianForwardFlatDir, Vector3.up);


        Vector3 verifDir = m_worldPlayerAxisRotation * Vector3.forward;
        Debug.DrawLine(m_worldPlayerAxisPosition, m_worldPlayerAxisPosition + verifDir, Color.magenta);

        GetWorldToLocal_DirectionalPoint(
            m_playerLeftHand.position, m_playerLeftHand.rotation,
            m_worldPlayerAxisPosition, m_worldPlayerAxisRotation,
            out m_localHandLeftPosition, out m_localHandLeftRotation);
        GetWorldToLocal_DirectionalPoint(
            m_playerRightHand.position, m_playerRightHand.rotation,
            m_worldPlayerAxisPosition, m_worldPlayerAxisRotation,
            out m_localHandRightPosition, out m_localHandRightRotation);
        GetWorldToLocal_DirectionalPoint(
            m_playerHead.position, m_playerHead.rotation,
            m_worldPlayerAxisPosition, m_worldPlayerAxisRotation,
            out m_localHeadPosition, out m_localHeadRotation);


        m_playerHeadRelocated.position = m_localHeadPosition;
        m_playerHeadRelocated.rotation = m_localHeadRotation;

        m_playerLeftHandRelocated.position = m_localHandLeftPosition;
        m_playerLeftHandRelocated.rotation = m_localHandLeftRotation;

        m_playerRightHandRelocated.position = m_localHandRightPosition;
        m_playerRightHandRelocated.rotation = m_localHandRightRotation;



        Debug.DrawLine(Vector3.zero, Vector3.forward, Color.blue);
        Debug.DrawLine(Vector3.zero, Vector3.right, Color.red);
        Debug.DrawLine(Vector3.zero, Vector3.up, Color.green);


    }

    public Vector3 m_localHandLeftPosition;
    public Quaternion m_localHandLeftRotation;

    public Vector3 m_localHandRightPosition;
    public Quaternion m_localHandRightRotation;

    public Vector3 m_localHeadPosition;
    public Quaternion m_localHeadRotation;


    #region RELOCATE POINTS
    public static void GetWorldToLocal_Point(in Vector3 worldPosition, in Transform rootReference, out Vector3 localPosition)
    {
        Vector3 positionReference = rootReference.position;
        Quaternion rotationReference = rootReference.rotation;
        GetWorldToLocal_Point(in worldPosition, in positionReference, in rotationReference, out localPosition);
    }

    public static void GetLocalToWorld_Point(in Vector3 localPosition, in Transform rootReference, out Vector3 worldPosition)
    {
        Vector3 positionReference = rootReference.position;
        Quaternion rotationReference = rootReference.rotation;
        GetLocalToWorld_Point(in localPosition, in positionReference, in rotationReference, out worldPosition);
    }

    public static void GetWorldToLocal_Point(in Vector3 worldPosition, in Vector3 positionReference, in Quaternion rotationReference, out Vector3 localPosition)
    {
        localPosition = Quaternion.Inverse(rotationReference) * (worldPosition - positionReference);
    }

    public static void GetLocalToWorld_Point(in Vector3 localPosition, in Vector3 positionReference, in Quaternion rotationReference, out Vector3 worldPosition)
    {
        worldPosition = rotationReference * localPosition + positionReference;
    }

    public static void GetWorldToLocal_DirectionalPoint(in Vector3 worldPosition, in Quaternion worldRotation, in Transform rootReference, out Vector3 localPosition, out Quaternion localRotation)
    {
        Vector3 positionReference = rootReference.position;
        Quaternion rotationReference = rootReference.rotation;
        GetWorldToLocal_DirectionalPoint(in worldPosition, in worldRotation, in positionReference, in rotationReference, out localPosition, out localRotation);
    }

    public static void GetLocalToWorld_DirectionalPoint(in Vector3 localPosition, in Quaternion localRotation, in Transform rootReference, out Vector3 worldPosition, out Quaternion worldRotation)
    {
        Vector3 positionReference = rootReference.position;
        Quaternion rotationReference = rootReference.rotation;
        GetLocalToWorld_DirectionalPoint(in localPosition, in localRotation, in positionReference, in rotationReference, out worldPosition, out worldRotation);
    }

    public static void GetWorldToLocal_DirectionalPoint(in Vector3 worldPosition, in Quaternion worldRotation, in Vector3 positionReference, in Quaternion rotationReference, out Vector3 localPosition, out Quaternion localRotation)
    {
        localRotation = Quaternion.Inverse(rotationReference) * worldRotation;
        localPosition = Quaternion.Inverse(rotationReference) * (worldPosition - positionReference);
    }

    public static void GetLocalToWorld_DirectionalPoint(in Vector3 localPosition, in Quaternion localRotation, in Vector3 positionReference, in Quaternion rotationReference, out Vector3 worldPosition, out Quaternion worldRotation)
    {
        worldRotation = localRotation * rotationReference;
        worldPosition = rotationReference * localPosition + positionReference;
    }

    public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
    {
        return RotatePointAroundPivot(point, pivot, Quaternion.Euler(angles));
    }

    public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion rotation)
    {
        return rotation * (point - pivot) + pivot;
    }
#endregion
}
