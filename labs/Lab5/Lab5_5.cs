// Найти "день программиста" (256-й день в году) для указанного года (ввести с консоли). Вывести дату и день недели.

#if false
class Lab5_5
{
    static void Main()
    {
        Console.Write("Введите год: ");
        string input = Console.ReadLine();

        if (!DateTime.TryParseExact(input, "yyyy", null,
                System.Globalization.DateTimeStyles.None, out DateTime date))
        {
            Console.WriteLine("Год не валиден");
            return;
        }

        date = date.AddDays(255);
        Console.WriteLine("Дата: {0}", date.ToString("dd/MM/yyyy"));
        Console.WriteLine("День недели: {0}", date.DayOfWeek);
    }
}
#endif