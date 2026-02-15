using System.Globalization;

#if false
class Lab7_2
{
    static void Main()
    {
        Console.Write("Введите своё имя: ");

        try
        {
            string name = Console.ReadLine();
            if(string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name), "Имя не может быть пустым!");

            Console.WriteLine($"Добро пожаловать, {name}!");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            Console.WriteLine("Привет, незнакомец!");
        }
    }
}
#endif