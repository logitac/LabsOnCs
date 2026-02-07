// Сумма чётных и произведение нечётных

#if false
class Lab4_1
{
    static void Main()
    {
        input:
        Console.Write("Введите количество чисел для обработки: ");
        if (!int.TryParse(Console.ReadLine(), out int n))
        {
            Console.WriteLine("Неверный ввод! (Нужно ввести число)");
            goto input;
        }
        
        
        int num, sumEven = 0, sumOdd = 1;
        for (int i = 1; i <= n; i++)
        {
            Console.Write("Введите число {0}: ", i);
            num = Convert.ToInt32(Console.ReadLine());

            if (num % 2 == 0)
                sumEven += num;
            else
                sumOdd *= num;
        }
        
        Console.WriteLine();
        Console.WriteLine("Результат: ");
        Console.WriteLine($"Сумма чётных чисел: {sumEven}");
        Console.WriteLine($"Произведение нечётных чисел: {sumOdd}");
    }
}
#endif

// Пример вывода программы: 
// Введите количество чисел: 4
// Введите число 1: 2
// Введите число 2: 3
// Введите число 3: 4
// Введите число 4: 5
//
// Результат:
// Сумма чётных чисел: 6
// Произведение нечётных чисел: 15