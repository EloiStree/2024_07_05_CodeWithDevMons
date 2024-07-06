using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditPageBehaviour : MonoBehaviour
{
    public string m_nextScene;
    public float m_autoLoadingTime = 5f;
    private bool m_sceneLoaderCall;
    public void OpenTargetUrl(string url)
    {
        Application.OpenURL(url);
    }

    void Update()
    {
        if (m_autoLoadingTime > 0)
        { 
        
        m_autoLoadingTime -= Time.deltaTime;
        }  
        else if (!m_sceneLoaderCall) {
            m_sceneLoaderCall = true;

            if (m_nextScene.Length > 0)
                SceneManager.LoadScene(m_nextScene);
            else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}
