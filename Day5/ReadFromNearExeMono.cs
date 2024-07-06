using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadFromNearExeMono : AbsoluteDirectPathFileMono
{

    public string m_fileName = "HelloWorld.txt";
    public override string GetFullDirectPathOfFileToRead()
    {
        return Path.Combine(Directory.GetCurrentDirectory(), m_fileName);
    }
}
