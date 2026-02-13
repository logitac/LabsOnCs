// Задан неупорядоченный список дней рождений в формате ДД.ММ.ГГГГ.
// Вывести  упорядоченный список месяцев с количеством дней рождений в этом месяце.

#if false
class Lab5_11
{
    static void Main()
    {
        List<DateTime> listBirthDays = new List<DateTime>();

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
            
            listBirthDays.Add(date);
        }

        var monthsCount = new int[12]; 

        foreach (DateTime bd in listBirthDays)
        {
            monthsCount[bd.Month - 1]++; 
        }
        
        Console.WriteLine("\nДни рождения по месяцам:");
        for (int i = 0; i < 12; i++)
        {
            if (monthsCount[i] > 0)
            {
                string monthName = new DateTime(2000, i + 1, 1).ToString("MMMM");
                Console.WriteLine($"{monthName}: {monthsCount[i]}");
            }
        }
    }
}
#endif