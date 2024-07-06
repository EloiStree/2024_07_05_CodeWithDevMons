using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToWebPage : MonoBehaviour
{
    public void Open(string url) {
        Application.OpenURL(url);
    }
}
