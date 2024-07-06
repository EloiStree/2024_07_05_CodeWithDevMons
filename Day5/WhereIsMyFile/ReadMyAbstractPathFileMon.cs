using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadMyAbstractPathFileMon : MonoBehaviour
{

    public string m_myText;

    public string m_filePath;
    public AbsoluteDirectPathFileMono m_fetchPath;

    // Start is called before the first frame update
    void Start()
    {
        m_filePath = m_fetchPath.GetFullDirectPathOfFileToRead();
        if (File.Exists(m_filePath))
        {
            m_myText= File.ReadAllText(m_filePath);
        }
    }

    [ContextMenu("Create file Hello")]
    public void CreateFileWithHello() {

        m_filePath = m_fetchPath.GetFullDirectPathOfFileToRead();
        File.WriteAllText(m_filePath, "Hello");
    }

}

public abstract class AbsoluteDirectPathFileMono : MonoBehaviour {

    public abstract string GetFullDirectPathOfFileToRead();

}
