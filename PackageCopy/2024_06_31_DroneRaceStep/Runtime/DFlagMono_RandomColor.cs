using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DFlagMono_RandomColor : MonoBehaviour
{

    public UnityEvent<Color> m_onColorChoosed;
    public bool m_changeColorAtAwake;


    private void Awake()
    {
        ChangeColor();
    }

    [ContextMenu("Change Color")]
    public void ChangeColor()
    {
        m_onColorChoosed.Invoke(new Color(Random.value, Random.value, Random.value, 1));
    }
}
