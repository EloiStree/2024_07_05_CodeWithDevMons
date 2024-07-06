using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLogMono : MonoBehaviour
{

    public void Log(string message)
    {
        Debug.Log(message);
    }
    public void LogA(string message)
    {
        Debug.Log("A:"+message);
    }
    public void LogB(string message)
    {
        Debug.Log("B:" + message);
    }
}
