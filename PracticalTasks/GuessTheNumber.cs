class GuessTheNumber
{
#if true    
    static void Main()
    {
        Random random = new Random();
        
        Console.Write("Выберете сложность (Лёгкий-1, Средний-2, Сложный-3, Невозможный-4): ");
        byte difficulty = byte.Parse(Console.ReadLine());
        int randomNumber, number = 0;
        switch (difficulty)
        {
            case 1:
                randomNumber = random.Next(1, 500);
                Console.WriteLine("Сложность выбрана. Режим сложности - Лёгкий. Диапозон: (1-500)");
                break;
            case 2:
                randomNumber = random.Next(1, 5000);
                Console.WriteLine("Сложность выбрана. Режим сложности - Средний. Диапозон: (1-5000)");
                break;
            case 3:
                randomNumber = random.Next(1, 20000);
                Console.WriteLine("Сложность выбрана. Режим сложности - Сложный. Диапозон: (1-20000)");
                break;
            case 4:
                randomNumber = random.Next(1, 100000);
                Console.WriteLine("Сложность выбрана. Режим сложности - Невозможный. Диапозон: (1-100000)");
                break;
            default:
                Console.WriteLine("Сложность не была выбрана!");
                return;
        }


        while (true)
        {
            Console.Write("Введите число: ");
            number = Convert.ToInt32(Console.ReadLine());

            if (number == randomNumber)
                break;
            
            if(number < randomNumber)
                Console.WriteLine("Больше!");
            else
                Console.WriteLine("Меньше!");
        }
        
        Console.WriteLine($"Поздравляю ты угадал! Число, которое было загадано - {randomNumber}");
    }
#endif    
}