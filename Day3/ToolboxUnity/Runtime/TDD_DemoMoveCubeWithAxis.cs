using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDD_DemoMoveCubeWithAxis : MonoBehaviour
{

    public Transform m_toTestAxis;

    public float m_joystickLeftX;

    public float m_joystickLeftY;

    public float m_joystickRightX;

    public float m_joystickRightY;




    public void SetJoystickLeftX(float joystickLeftX) => m_joystickLeftX = joystickLeftX;

    public void SetJoystickLeftY(float joystickLeftY) => m_joystickLeftY = joystickLeftY;

    public void SetJoystickRightX(float joystickRightX) => m_joystickRightX = joystickRightX;

    public void SetJoystickRightY(float joystickRightY) => m_joystickRightY = joystickRightY;


    void Update()
    {
        m_toTestAxis.transform.localScale = new Vector3(0.5f + m_joystickLeftX, 0.5f + m_joystickLeftY, 0.5f + m_joystickRightX);
        m_toTestAxis.transform.localPosition = new Vector3(0, 0.5f + m_joystickRightY, 0);
    }
}