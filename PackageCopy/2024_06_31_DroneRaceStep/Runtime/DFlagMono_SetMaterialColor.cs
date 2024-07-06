using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DFlagMono_SetMaterialColor : MonoBehaviour
{
    public Material [] m_whatToAffect;
    public Renderer [] m_renderer;

    public void SetColor(Color givenColor) {

        foreach (var item in m_whatToAffect)
        {
            item.color = givenColor;
        }
        foreach (var item in m_renderer)
        {
            item.material.color = givenColor;
        }
    }
}
