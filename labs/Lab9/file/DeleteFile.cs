using System.IO;

#if trueq
class DeleteFile
{
    static void Main(string[] args)
    {
        string path = @"C:\Games\Posxalko.txt";
        FileInfo fileInf = new FileInfo(path);
        if (fileInf.Exists)
        {
            fileInf.Delete();
            // альтернатива с помощью класса File
            // File.Delete(path);
        }
    }
}
#endif