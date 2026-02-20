using System.IO;
using System.Text;

#if trueq
class UsingStreamReader
{
    static async Task Main()
    {
        string path = @"C:/SomeDir/hta.txt";

        try
        {
            using (StreamReader sr = new StreamReader(path))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
            
            // Асинхронное чтение
            using (StreamReader sr = new StreamReader(path))
            {
                Console.WriteLine(await sr.ReadToEndAsync());
            }
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
#endif