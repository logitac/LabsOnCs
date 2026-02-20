using System.IO;
using System.Text;

#if trueq
class UsingStreamWriter
{
    static void Main()
    {
        string writePath = @"C:/SomeDir/hta.txt";
        string text = "Hello World!\nПока мир...";
        try
        {
            using (StreamWriter sw = new StreamWriter(writePath, false, Encoding.Default))
            {
                sw.WriteLine(text);
            }

            using (StreamWriter sw = new StreamWriter(writePath, true, Encoding.Default))
            {
                sw.WriteLine("Дозапись");
                sw.Write(4.5);
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