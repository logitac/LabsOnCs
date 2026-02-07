#if false
class Lab4_4
{
    static void Main()
    {
        Console.Write("Введите последовательность: ");
        string input = Console.ReadLine();

        int count = 0;
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Строка не может быть пустой!");
            return;
        }
        
        for (int i = 0; i < input.Length; i++)
        {
            if (i + 4 < input.Length)
            {
                bool isArrow = true;

                for (int j = 0; j < 5; j++)
                {
                    if (input[i + j] != "<--<<"[j])
                    {
                        isArrow = false;
                        break;
                    }
                }

                if (isArrow)
                {
                    count++;
                    i += 4;
                    continue;
                }
                
                isArrow = true;
                for (int j = 0; j < 5; j++)
                {
                    if (input[i + j] != ">>-->"[j])
                    {
                        isArrow = false;
                        break;
                    }
                }

                if (isArrow)
                {
                    count++;
                    i += 4;
                }
            }
        }

        Console.WriteLine(count);
    }
}
#endif

// Пример вывода программы:

// Введите последовательность: <--<<>>-->>>-<<<->>-->
// 3
// Введите последовательность: <--<<
// 1