using System.IO;

#if false
class CreateDirectory
{
    static void Main()
    {
        string path = @"C:\SomeDir";
        string subpath = @"program\avalon";
        DirectoryInfo dirInfo = new DirectoryInfo(path);
        if (!dirInfo.Exists)
        {
            dirInfo.Create();
        }
        dirInfo.CreateSubdirectory(subpath);
    }
}
#endif