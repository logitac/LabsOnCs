using System.IO;
using System.Text;


#if trueq
class UsingStreamReaderLine
{
    static async Task Main()
    {
        string path= @"C:\SomeDir\hta.txt";
        using (StreamReader sr = new StreamReader(path, Encoding.Default))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
        
        // Асинхронное чтение
        using (StreamReader sr = new StreamReader(path, Encoding.Default))
        {
            string line;
            while ((line = await sr.ReadLineAsync()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}
#endif