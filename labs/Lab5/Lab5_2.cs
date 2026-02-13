// Найти количество дней между двумя датами.

#if false
class Lab5_2
{
    static void Main()
    {
        Console.Write("Введите первую дату в формате (ДД.ММ.ГГГГ): ");
        string date1Input = Console.ReadLine();
        Console.Write("Введите вторую дату в формате (ДД.ММ.ГГГГ): ");
        string date2Input = Console.ReadLine();

        if (!DateTime.TryParseExact(date1Input, "dd.MM.yyyy", null,
                System.Globalization.DateTimeStyles.None, out DateTime date1))
        {
            Console.WriteLine("Первая дата невалидна!");
            return;
        }

        if (!DateTime.TryParseExact(date2Input, "dd.MM.yyyy", null,
                System.Globalization.DateTimeStyles.None, out DateTime date2))
        {
            Console.WriteLine("Вторая дата невалидна!");
            return;
        }
        
        TimeSpan ts = date1 - date2;
        Console.WriteLine(Math.Abs(ts.Days));
    }
}
#endif