using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;
using UnityEngine;

public class SendUDPTextMono : MonoBehaviour
{

    public string m_ipTarget = "127.0.0.1";
    public int m_portTarget = 2504;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [ContextMenu("Send Random 0 100")]
    public void SendRandom100()
    {
        
        SendText(""+(UnityEngine.Random.Range(0,100)));

    }

    [ContextMenu("Send Random GUID")]
    public void SendRandomGUID() { 
        SendText(System.Guid.NewGuid().ToString());
    
    }

    public void SendText(string text) { 
    
        SendUdpMessage(text, m_ipTarget, m_portTarget);
    }

    static void SendUdpMessage(string message, string ipAddress, int port)
    {
        using (UdpClient udpClient = new UdpClient())
        {
            try
            {
                // Convert the message to bytes
                byte[] sendBytes = Encoding.UTF8.GetBytes(message);

                // Create an endpoint with the specified IP address and port
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);

                // Send the message 
                udpClient.Send(sendBytes, sendBytes.Length, endPoint);

                Debug.Log("Sent message: " + message);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}
