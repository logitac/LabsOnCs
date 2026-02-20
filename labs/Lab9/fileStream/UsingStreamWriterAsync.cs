using System.IO;
using System.Text;

#if trueq
class UsingStreamWriterAsync
{
    static async Task Main()
    {
        string writePath = @"C:/SomeDir/hta.txt";
        string text = "Hello World!\nПока мир...";
        try
        {
            using (StreamWriter sw = new StreamWriter(writePath, false, Encoding.Default))
            {
                await sw.WriteLineAsync(text);
            }

            using (StreamWriter sw = new StreamWriter(writePath, true, Encoding.Default))
            {
                await sw.WriteLineAsync("Дозапись");
                await sw.WriteAsync("4,5");
            }

            Console.WriteLine("Запись выполнена");
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
#endif