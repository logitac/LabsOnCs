using System;
using System.IO;
using System.Text;


#if trueq
class UsingSeek
{
    static void Main(string[] args)
    {
        string text = "hello world";

        using (FileStream fstream = new FileStream($"C:/SomeDir/note.dat", FileMode.OpenOrCreate))
        {
            byte[] input = System.Text.Encoding.Default.GetBytes(text);
            fstream.Write(input, 0, input.Length);
            Console.WriteLine("Текст записан в файл");
            
            fstream.Seek(-5, SeekOrigin.End);

            byte[] output = new byte[4];
            fstream.Read(output, 0, output.Length);
            string textFromFile = Encoding.UTF8.GetString(output);
            Console.WriteLine($"Текст из файла: {textFromFile}"); // worl

            string replaceText = "house";
            fstream.Seek(-5, SeekOrigin.End);
            input = Encoding.Default.GetBytes(replaceText);
            fstream.Write(input, 0, input.Length);
            
            fstream.Seek(0, SeekOrigin.Begin);
            output = new byte[fstream.Length];
            fstream.Read(output, 0, output.Length);
            textFromFile = Encoding.Default.GetString(output);
            Console.WriteLine($"Текст из файла: {textFromFile}");
        }
    }
}
#endif