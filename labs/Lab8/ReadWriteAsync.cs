using System;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

#if false
class ReadWriteAsync
{
    static void Main(string[] args)
    {
        ReadWriteAsyncc();

        Console.WriteLine("Некоторая работа");
        Console.Read();
    }

    static async void ReadWriteAsyncc()
    {
        string s = "Hello world! One step at a time";
        
        string path = Path.GetFullPath("hello.txt");
        Console.WriteLine($"Файл будет здесь: {path}");
        
        using (StreamWriter writer = new StreamWriter("hello.txt", false))
        {
            await writer.WriteLineAsync(s);    
        }

        using (StreamReader reader = new StreamReader("hello.txt"))
        {
            string result =  await reader.ReadToEndAsync();
            Console.WriteLine(result);
        }
    }
}
#endif