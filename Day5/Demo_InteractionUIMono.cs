using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Demo_InteractionUIMono : MonoBehaviour
{

    public Image m_imageToAffect;
    public InputField m_textToAffect;
    public RawImage m_rawImage;

    [Range(0,1f)]
    public float m_percentageLife = 1.0f;
    public RenderTexture m_renderTexture;
    void Update()
    {
        m_imageToAffect.fillAmount = m_percentageLife;
        m_textToAffect.text = m_percentageLife.ToString();
        m_rawImage.texture = m_renderTexture;
    }
}
