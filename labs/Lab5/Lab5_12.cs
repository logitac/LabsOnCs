// Поиск наиболее популярного месяца: объявите массив произвольных дат в формате ДД.ММ.ГГГГ. Найдите самый популярный месяц.

#if false
class Lab5_12
{
    static void Main()
    {
        List<DateTime> listDateTime = new List<DateTime>();

        Console.WriteLine("Enter a date in the format (dd.MM.yyyy): ");

        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                break;

            if (!DateTime.TryParseExact(input, "dd.MM.yyyy", null,
                    System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                Console.WriteLine("Invalid date");
                continue;
            }
            
            listDateTime.Add(date);
        }

        var monthCounter = new int[12];
        foreach (DateTime bt in listDateTime)
        {
            monthCounter[bt.Month - 1]++; 
        }

        int mostPopularMonth = 0;
        int max = Int32.MinValue;

        for (int i = 0; i < 12; i++)
        {
            if (max < monthCounter[i])
            {
                max = monthCounter[i];
                mostPopularMonth = i+1;
            }
        }

        string monthName = new DateTime(2000, mostPopularMonth, 1).ToString("MMMM");
        Console.WriteLine($"Популярный месяц: {monthName}");
    }
}
#endif