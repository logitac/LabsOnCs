// Вывести дату в формате ДД.ММ.ГГГГ для "завтра"

#if false
class Lab5_7
{
    static void Main()
    {
        Console.Write("Введите дату в формате (ДД.ММ.ГГГГ): ");
        string input = Console.ReadLine();
        
        if (!DateTime.TryParseExact(input, "dd.MM.yyyy", null,
                System.Globalization.DateTimeStyles.None, out DateTime date))
        {
            Console.WriteLine("Дата невалидна!");
        }
        else
            Console.WriteLine($"Дата на завтра: {date.AddDays(1).ToString("dd.MM.yyyy")}");
    }
}
#endif