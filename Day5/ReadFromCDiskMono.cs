using System.IO;

public class ReadFromCDiskMono : AbsoluteDirectPathFileMono
{

    public string m_folderPath=  "C:\\";
    public string m_fileName = "HelloWorld.txt";
    public override string GetFullDirectPathOfFileToRead()
    {
        return Path.Combine(m_folderPath, m_fileName);
    }
}
