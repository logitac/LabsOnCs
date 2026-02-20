using System.IO;

#if false
class GetFileInfo
{
    static void Main(string[] args)
    {
        string path = @"C:/Games/Posxalko.txt";
        FileInfo fileInf = new FileInfo(path);
        if (fileInf.Exists)
        {
            Console.WriteLine("Имя файла: {0}", fileInf.Name);
            Console.WriteLine("Время создания: {0}", fileInf.CreationTime);
            Console.WriteLine("Размер: {0}", fileInf.Length + " байта");
        }
    }
}
#endif