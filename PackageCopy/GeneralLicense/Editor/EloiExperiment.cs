using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EloiExperiment : MonoBehaviour
{
    public const string EDITORMENUSTART = "ꬲ🧰";
    public const string INFOMENU = "✋ Hi you...";
   
    
    [MenuItem(EDITORMENUSTART + "/" + INFOMENU , true, 1)]
    [MenuItem(EDITORMENUSTART + "/" + INFOMENU + "/❗ GitHub & Linked In ", false, 10000)]
    static void Contact()
    {
        Application.OpenURL("https://github.com/EloiStree/");
    }

    [MenuItem(EDITORMENUSTART + "/" + INFOMENU + "/☕ Donation & License", false, 9996)]
    static void License()
    {
        Application.OpenURL("https://en.tipeee.com/eloilab");
    }


    [MenuItem(EDITORMENUSTART + "/" + INFOMENU + "/🐞 Report Bug", false, 9997)]
    static void Issue()
    {
        Application.OpenURL("https://github.com/EloiStree/EloiStree/issues");
    }
    [MenuItem(EDITORMENUSTART + "/" + INFOMENU + "/💬 Discord talk", false, 9998)]
    static void Discord()
    {
        Application.OpenURL("https://eloistree.github.io/r/discord");
    }
  
    
    [MenuItem(EDITORMENUSTART + "/🧰 How to use...", false, 10002)]
    static void HowToUse()
    {
        Application.OpenURL("https://github.com/EloiStree/UnityToolbox/discussions/26");
    }
    //[MenuItem(EDITORMENUSTART + "/" + INFOMENU + "/ Yo !", false, 10003)]
    static void WhoAmI()
    {
        Application.OpenURL("https://eloistree.page.link/whoami");
    }

}
