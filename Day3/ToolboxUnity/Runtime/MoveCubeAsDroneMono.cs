using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubeAsDroneMono : MonoBehaviour
{
    public Transform m_toMove;

    [Header("Axis")]
    [Tooltip("C'est un axis pour bouger le drone vers l'avant")]
    public float m_rotateLeftRight;

    public Vector3 m_direction;
    public float m_speedMove = 1;
    public float m_speedRotate = 180;


    [Header("Speed")]
    public float m_moveForwardSpeed = 2;



    public void SetRotateLeftRigh(float valuePercent11)
    {
        m_rotateLeftRight = valuePercent11;
    }
    public void SetMoveForward(float valuePercent11)
    {
        m_direction.z = valuePercent11;
    }
    public void SetMoveRight(float valuePercent11)
    {
        m_direction.x = valuePercent11;
    }
    public void SetMoveUp(float valuePercent11)
    {
        m_direction.y = valuePercent11;
    }


    public Space m_rotateSpaceType = Space.World;
    public void Update()
    {
        m_toMove.Translate(m_direction * Time.deltaTime * m_speedMove, Space.Self);
        m_toMove.Rotate(Vector3.up, m_rotateLeftRight * Time.deltaTime * m_speedRotate, m_rotateSpaceType);
    }


    private void Reset()
    {
        m_toMove = transform;
    
    }

  
    
}
