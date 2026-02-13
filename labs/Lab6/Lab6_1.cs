// Будем рассматривать только строчки, состоящие из заглавных английских букв.
// Например, рассмотрим строку AAAABCCCCCDDDD. Длина этой строки равна 14.
// Поскольку строка состоит только из английских букв, повторяющиеся символы могут быть удалены и заменены числами,
// определяющими количество повторений. Таким образом, данная строка может быть представлена как 4AB5C4D.
// Длина такой строки 7. Описанный метод мы назовем упаковкой строки.

// Напишите программу, которая берет упакованную строчку и восстанавливает по ней исходную строку.

#if false
class Lab6_1
{
    static void Main()
    {
        Console.Write("Введите строку заглавными буквами: "); // AAAABCCCCCDDDD
        string input = Console.ReadLine();

        input = PackingString(input);
        Console.WriteLine(input);
        
        input = UnPackingString(input);
        Console.WriteLine(input);
    }

    static string PackingString(string input)
    {
        string packingInput = "";
        int i = 0;

        while (i < input.Length)
        {
            char currentChar = input[i];
            int count = 1;

            
            while (i + 1 < input.Length && input[i + 1] == currentChar)
            {
                count++;
                i++;
            }

            
            if (count > 1)
                packingInput += count.ToString() + currentChar;
            else
                packingInput += currentChar;

            i++;
        }
        
        return packingInput;
    }

    static string UnPackingString(string input) // 4AB5C4D
    {
        string UnPackingInput = "";
        int i = 0;
        
        while (i < input.Length)
        {
            if (Char.IsDigit(input[i]))
            {
                string countString = "";
                while (i < input.Length && Char.IsDigit(input[i]))
                {
                    countString += input[i];
                    i++;
                }
                
                int count = int.Parse(countString);
                char symbol = input[i];

                for (int j = 0; j < count; j++)
                {
                    UnPackingInput += symbol;
                }

                i++;
            }
            else
            {
                UnPackingInput += input[i];
                i++;
            }
        }
        
        return UnPackingInput;
    }
}
#endif