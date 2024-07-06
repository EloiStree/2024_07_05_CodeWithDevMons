
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class SaveMyGenericClassMono<T> : MonoBehaviour
{

    public T m_valueToSave;


    [TextArea(2,6)]
    public string m_jsonFileContent;
    public string m_fileNameWithExtension="Name.txt";


    public void Reset()
    {
        GenereNewGUID();
    }

    [ContextMenu("New GUID")]
    private void GenereNewGUID()
    {
        m_fileNameWithExtension = GUID.Generate().ToString() + ".txt";
    }

    void Start()
    {


        string path = FetchPath();
        if (File.Exists(path))
        {
            m_jsonFileContent = File.ReadAllText(path);
            m_valueToSave = JsonUtility.FromJson< T>(m_jsonFileContent);
        }
    }
    private string FetchPath()
    {
        return Application.persistentDataPath + "\\" + m_fileNameWithExtension;
    }

    private void OnDestroy()
    {
        File.WriteAllText(FetchPath(), JsonUtility.ToJson(m_valueToSave,true));
    }
    [ContextMenu("Open Folder")]
    void OpenFolder()
    {
        Application.OpenURL(Application.persistentDataPath);
    }
    [ContextMenu("Open Save File")]
    void OpenSaveFile()
    {
        Application.OpenURL(FetchPath());
    }

}
[System.Serializable]
public class ExamplHowToSave
{

    public float m_cutFruit;
    public float m_maxTime;
}

// PlayerPrefs.SetString("Key", JsonUtility.ToJson(m_valueToSave));



public class SaveExampleHowToSaveMono : SaveMyGenericClassMono<ExamplHowToSave>
{

}
