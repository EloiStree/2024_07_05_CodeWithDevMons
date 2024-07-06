using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericClassDemoMono : MonoBehaviour
{
    public NetworkPlayerData_Life m_life;
    public NetworkPlayerData_Position m_position;
    public NetworkPlayerData_Rotation m_rotation;

    [System.Serializable]
    public class NetworkPlayerData <T>{

        public int m_uniqueID;
        public T m_value;
        public long m_timeStampWehnReceved;
    }

    [System.Serializable]
    public class NetworkPlayerData_Life : NetworkPlayerData<float>
    {
    }
    [System.Serializable]
    public class NetworkPlayerData_Position : NetworkPlayerData<Vector3>
    {
    }
    [System.Serializable]
    public class NetworkPlayerData_Rotation : NetworkPlayerData<Quaternion>
    {
    }
}
