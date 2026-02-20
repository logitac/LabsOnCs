using System.IO;
using System.Text;

#if trueq
class ReadAndWriteFile
{
    static void Main()
    {
        string path = @"C:/SomeDir";
        DirectoryInfo dir = new DirectoryInfo(path);
        if(!dir.Exists)
            dir.Create();

        Console.Write("Введите строку для записи в файл: ");
        string text = Console.ReadLine();

        using (FileStream fstream = new FileStream($"{path}/note.txt", FileMode.OpenOrCreate))
        {
            byte[] buffer = System.Text.Encoding.Default.GetBytes(text);
            fstream.Write(buffer, 0, buffer.Length);
            Console.WriteLine("Текст записан в файл");
        }

        using (FileStream fstream = File.OpenRead($"{path}/note.txt"))
        {
            byte[] buffer = new byte[fstream.Length];
            fstream.Read(buffer, 0, buffer.Length);
            string textFromFile = System.Text.Encoding.Default.GetString(buffer);
            Console.WriteLine($"Текст из файла: {textFromFile}");
        }
    }
}
#endif