using System.IO;
using System.Threading.Tasks;
using System.Text;

#if trueq
class ReadAndWriteFileAsync
{
    static async Task Main()
    {
        string path = @"C:/SomeDir";
        DirectoryInfo dir = new DirectoryInfo(path);
        if(!dir.Exists)
            dir.Create();
        Console.Write("Введите строку для записи в файл: ");
        string text = Console.ReadLine();

        using (FileStream fs = new FileStream($"{path}/note.txt", FileMode.OpenOrCreate))
        {
            byte[] bytes = System.Text.Encoding.Default.GetBytes(text);
            await fs.WriteAsync(bytes, 0, bytes.Length);
            Console.WriteLine("Текст записан в файл");
        }

        using (FileStream fs = File.OpenRead($"{path}/note.txt"))
        {
            byte[] bytes = new byte[fs.Length];
            await fs.ReadAsync(bytes, 0, bytes.Length);
            string textFromFile = System.Text.Encoding.Default.GetString(bytes);
            Console.WriteLine($"Текст из файла: {textFromFile}");
        }
    }
}
#endif