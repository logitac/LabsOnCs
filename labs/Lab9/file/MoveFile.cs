using System.IO;

#if trueq
class MoveFile
{
    static void Main()
    {
        string path = @"C:\apache\hta.txt";
        string newPath = @"C:\SomeDir\hta.txt";
        FileInfo fileInf = new FileInfo(path);
        if (fileInf.Exists)
        {
            fileInf.MoveTo(newPath);       
            // альтернатива с помощью класса File
            // File.Move(path, newPath);
        }
    }
}
#endif