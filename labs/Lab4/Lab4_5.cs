#if false
class Lab4_5
{
    static void Main(string[] args)
    {
        Console.Write("Введите ваше время жизни в секундах: ");
        int lifeTime = Convert.ToInt32(Console.ReadLine());

        int number = 0;
        int counter = 0;
        while (lifeTime > 0)
        {
            int temp = lifeTime % 10;
            number += temp;
            lifeTime /= 10;
            counter++;
        }

        Console.WriteLine($"Итоговая цифра: {number}");
        Console.WriteLine($"Количество операций: {counter}");
    }
}
#endif

//Пример вывода программы:

// Введите ваше время жизни в секундах: 423652
// Итоговая цифра: 22
// Количество операций: 6