using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorRenderMono : MonoBehaviour
{
    public MeshRenderer[] m_changeColorTarget; 
   
    public void ChangeColor(Color color)
    {
        foreach (var meshRenderer in m_changeColorTarget)
        {
            if(meshRenderer != null)
            meshRenderer.material.color = color;
        }
    }

    [ContextMenu("Push Random Color")]
    public void PushRandomColor() { 
    
        ChangeColor(new Color(Random.value, Random.value, Random.value));
    }
}
