using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone8x8x8Mono_WhatToMove : MonoBehaviour
{
    [Tooltip("Must be at center of the 8x8x8 square on the bottom of the square and not in the middle")]
    public Transform m_whatToMove;
    private void Reset()
    {
        m_whatToMove = transform;
    }
}
