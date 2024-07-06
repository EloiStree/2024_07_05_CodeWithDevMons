using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class MoveCubeFromInputMono : MonoBehaviour
{
   public InputActionReference m_moveForward;
   public InputActionReference m_movebackward;
   public InputActionReference m_moveLeft;
   public InputActionReference m_moveRight;


    public Transform m_cubeToMove;


    public BoolChangeEvent m_isMovingForward;


    [System.Serializable]
    public class BoolChangeEvent {
        public bool m_currentValue;

        public UnityEvent<bool> m_onValueChanged;
        public UnityEvent m_onTrue;
        public UnityEvent m_onFalse;

        public void SetNewValue(bool newValue)
        {
            bool changed = m_currentValue != newValue;
            m_currentValue = newValue;

            if (changed) { 
            
                m_onValueChanged.Invoke(m_currentValue);
                if (m_currentValue)
                {
                    m_onTrue.Invoke();
                }
                else
                {
                    m_onFalse.Invoke();
                }
            }

        }
    }


   

    public void OnEnable()
    {
        m_moveForward.action.Enable();
        m_movebackward.action.Enable();
        m_moveLeft.action.Enable();
        m_moveRight.action.Enable();
        //m_moveForward.action.performed += (e) => { };
        m_moveForward.action.performed += MoveForward;
        m_moveForward.action.canceled += MoveForward;

    }


    private void MoveForward(InputAction.CallbackContext context)
    {
        m_isMovingForward.SetNewValue(context.ReadValueAsButton());

    }
}





//public UnityEvent<Vector2> m_joystickLeft;
//public UnityEvent<Vector2> m_joystickRight;

//[SerializeField]
//private InputActionReference m_joystickLeftReference;
//[SerializeField]
//private InputActionReference m_joystickRightReference;

//[SerializeField]
//public Vector2 m_joystickLeftValue;
//[SerializeField]
//public Vector2 m_joystickRightValue;

//private void OnEnable()
//{
//    if (m_joystickLeftReference != null)
//    {
//        m_joystickLeftReference.action.Enable();
//        m_joystickLeftReference.action.performed += OnMoveLeft;
//        m_joystickLeftReference.action.canceled += OnMoveCanceledLeft;
//    }
//    if (m_joystickRightReference != null)
//    {
//        m_joystickRightReference.action.Enable();
//        m_joystickRightReference.action.performed += OnMoveRight;
//        m_joystickRightReference.action.canceled += OnMoveCanceledRight;
//    }
//}

//private void OnDisable()
//{
//    if (m_joystickLeftReference != null)
//    {
//        m_joystickLeftReference.action.performed -= OnMoveLeft;
//        m_joystickLeftReference.action.canceled -= OnMoveCanceledLeft;
//        m_joystickLeftReference.action.Disable();
//    }
//    if (m_joystickRightReference != null)
//    {
//        m_joystickRightReference.action.performed -= OnMoveRight;
//        m_joystickRightReference.action.canceled -= OnMoveCanceledRight;
//        m_joystickRightReference.action.Disable();
//    }
//}

//private void OnMoveLeft(InputAction.CallbackContext context)
//{
//    m_joystickLeftValue = context.ReadValue<Vector2>();
//    m_joystickLeft.Invoke(m_joystickLeftValue);
//}

//private void OnMoveCanceledLeft(InputAction.CallbackContext context)
//{
//    m_joystickLeftValue = Vector2.zero;
//    m_joystickLeft.Invoke(m_joystickLeftValue);
//}
//private void OnMoveRight(InputAction.CallbackContext context)
//{
//    m_joystickRightValue = context.ReadValue<Vector2>();
//    m_joystickRight.Invoke(m_joystickRightValue);
//}

//private void OnMoveCanceledRight(InputAction.CallbackContext context)
//{
//    m_joystickRightValue = Vector2.zero;
//    m_joystickRight.Invoke(m_joystickRightValue);
//}