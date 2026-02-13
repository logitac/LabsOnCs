// Часы показывают время в формате hh:mm:ss. Определите количество секунд, которое прошло с начала суток.

#if false
class Lab5_9
{
    static void Main()
    {
        Console.Write("Введите текущее время в формате (чч:мм): ");
        string input = Console.ReadLine();

        if (!DateTime.TryParseExact(input, "HH:mm:ss", null, 
                System.Globalization.DateTimeStyles.None, out DateTime time))
        {
            Console.WriteLine("Время не валидное");
            return;
        }

        int totalSeconds = time.Hour * 3600 + time.Minute * 60 + time.Second;
        Console.WriteLine("Секунд прошло с начала суток: {0}", totalSeconds);
    }
}
#endif