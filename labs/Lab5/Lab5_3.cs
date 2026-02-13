// Найти количество часов между двумя датами.

#if false
class Lab5_3
{
    static void Main(string[] args)
    {
        Console.Write("Введите первую дату в формате (ДД.ММ.ГГГГ ЧЧ.ММ): ");
        string date1Input = Console.ReadLine();
        Console.Write("Введите вторую дату в формате (ДД.ММ.ГГГГ ЧЧ.ММ): ");
        string date2Input = Console.ReadLine();

        if (!DateTime.TryParseExact(date1Input, "dd.MM.yyyy HH:mm", null,
                System.Globalization.DateTimeStyles.None, out DateTime date1))
        {
            Console.WriteLine("Первая дата невалидна!");
            return;
        }

        if (!DateTime.TryParseExact(date2Input, "dd.MM.yyyy HH:mm", null,
                System.Globalization.DateTimeStyles.None, out DateTime date2))
        {
            Console.WriteLine("Вторая дата невалидна!");
            return;
        }
        
        TimeSpan difference = date1 - date2;
        int wholeHours = Math.Abs(difference.Hours) + Math.Abs(difference.Days * 24);
        Console.WriteLine($"Разница: {wholeHours:F2}");
    }
}
#endif