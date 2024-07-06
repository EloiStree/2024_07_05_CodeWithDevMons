using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugStaticZhuLiReceiverMono : MonoBehaviour
{
    public string m_typeReceived;
    [TextArea(2,8)]
    public string m_receivedThingToDo;
    public void OnEnable()
    {
        ZhuLi.AddListener(DebugTheThing);
    }

    public void OnDisable()
    {
        ZhuLi.RemoveListener(DebugTheThing);
    }

    private void DebugTheThing(IZhuLiCommand theThingToDo)
    {
        m_receivedThingToDo= JsonUtility.ToJson(theThingToDo);
        m_typeReceived = theThingToDo.GetType().ToString();
    }
}
