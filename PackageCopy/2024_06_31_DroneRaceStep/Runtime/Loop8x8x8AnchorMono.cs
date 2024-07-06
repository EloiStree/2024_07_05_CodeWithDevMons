using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop8x8x8AnchorMono : MonoBehaviour
{
    [Header("Corner")]
    public Transform m_topLeftCorner;
    public Transform m_topRightCorner;
    public Transform m_downLeftCorner;
    public Transform m_downRightCorner;

    [Header("Line")]
    public Transform m_topLeftLine;
    public Transform m_topRightLine;
    public Transform m_bottomLeftLine;
    public Transform m_bottomRightLine;
    public Transform m_leftTopLine;
    public Transform m_leftDownLine;
    public Transform m_rightTopLine;
    public Transform m_rightDownLine;


}
