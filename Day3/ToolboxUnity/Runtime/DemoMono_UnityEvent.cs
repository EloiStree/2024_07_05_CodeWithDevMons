using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DemoMono_UnityEvent : MonoBehaviour
{

    public delegate void OnGameTimeChange(float time);
    public OnGameTimeChange m_onChangedTimeDelegate;

    public Action<float> m_onGameTimeCS;
    public UnityEvent m_onAction;
    public UnityEvent<float> m_onGameTime;


    private void Awake()
    {
        m_onAction.AddListener(DitBonjour);
        m_onGameTimeCS += DisplayGameTime;
        m_onChangedTimeDelegate += DisplayGameTime;


        
    }

    private void DitBonjour()
    {
        Debug.Log("Bonjour");
    }
    private void DisplayGameTime(float time)
    {
        Debug.Log("Time");
    }

    void Start()
    {
        m_onAction.Invoke();
        m_onChangedTimeDelegate.Invoke(Time.time);
        m_onGameTime.Invoke(Time.time);
    }

    void Update()
    {
        //m_onGameTime.Invoke(Time.time);

        //if(m_onGameTimeCS!=null)
        //    m_onGameTimeCS(Time.time);
        
    }

    public float m_gameTime;
    public void SetGameTime(float gameTime)
    {
        m_gameTime = gameTime;
    }
}
