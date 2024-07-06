using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone8x8x8Tag_SquareIndex : Drone8x8x8_Default
{

    [Header("Don't use zero")]
    public int m_indexLeftToRightX;
    public int m_indexBackToFrontZ;

    private void OnValidate()
    {
       if(m_indexLeftToRightX==0)
        {
            m_indexLeftToRightX = 1;
        }
        if (m_indexBackToFrontZ == 0)
        {
            m_indexBackToFrontZ = 1;
        }
    }
}
