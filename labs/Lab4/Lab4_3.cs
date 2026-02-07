using System.Text;

#if false
class Lab4_3
{
    static void Main()
    {
        Console.Write("Введите бинарную последовательность (0 и 1): ");
        string binarySequence = Console.ReadLine();
        StringBuilder compressed = new StringBuilder();
        
        int count = 0;
        if (binarySequence.Length == 0)
        {
            Console.WriteLine("Введите бинарную последовательность!!!");
            return;
        }
        else
        {
            for (int sym = 0; sym < binarySequence.Length; sym++)
            {
                
                if (binarySequence[sym] != '0' && binarySequence[sym] != '1')
                {
                    compressed.Append("Пусто");
                    break;
                }
                else if (binarySequence[sym] == '0')
                {
                    count++;
                }
                else if (binarySequence[sym] == '1')
                {
                    char compressedChar = (char)('a' + count);
                    compressed.Append(compressedChar);
                    count = 0;
                }
            }
        }

        Console.WriteLine(compressed);
    }
}
#endif

// Пример вывода программы:

// Введите бинарную последовательность (0 и 1): 000001
// f
// Введите бинарную последовательность (0 и 1): 0000010001000010001011
// fdedba