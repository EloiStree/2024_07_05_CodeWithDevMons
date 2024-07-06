using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LoopCoroutineTickMono : MonoBehaviour
{
    public float m_intervaleTick = 0.1f;
    public UnityEvent m_onTick;
    IEnumerator Start()
    {
        while (true) {

            yield return new WaitForEndOfFrame();
            yield return new WaitForSeconds(m_intervaleTick);
            m_onTick.Invoke();
        }
    }

}
