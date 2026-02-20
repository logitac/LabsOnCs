using System.IO;

#if false
class GetSubDirectoriesAndListFiles
{
    static void Main()
    {
        string dirName = "C:/";

        if (Directory.Exists(dirName))
        {
            Console.WriteLine("Подкаталоги:");
            string[] dirs = Directory.GetDirectories(dirName);
            foreach (string dir in dirs)
            {
                Console.WriteLine(dir);
            }
            Console.WriteLine();

            Console.WriteLine("Файлы:");
            string[] files = Directory.GetFiles(dirName);
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
        }
    }
}
#endif