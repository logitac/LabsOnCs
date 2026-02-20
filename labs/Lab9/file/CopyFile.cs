using System.IO;

#if trueq
class CopyFile
{
    static void Main()
    {
        string path = @"C:\apache\hta.txt";
        string newPath = @"C:\SomeDir\hta.txt";
        FileInfo fileInf = new FileInfo(path);
        if (fileInf.Exists)
        {
            fileInf.CopyTo(newPath, true);      
            // альтернатива с помощью класса File
            // File.Copy(path, newPath, true);
        }
    }
}
#endif