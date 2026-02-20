using System.IO;

#if false
class DeleteDirectory
{
    static void Main()
    {
        string dirName = @"C:/SomeDir";

        try
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dirName);
            dirInfo.Delete(true);
            Console.WriteLine("Каталог успешно удалён");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}
#endif