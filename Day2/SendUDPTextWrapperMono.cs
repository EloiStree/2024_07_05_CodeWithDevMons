using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendUDPTextWrapperMono : MonoBehaviour
{
    public SendUDPTextMono m_sender;
    public string m_textToSend = "Hello World";
    [ContextMenu("Send text")]
    public void SendTextInInspector() { 
    
        m_sender.SendText(m_textToSend);
    }
}
