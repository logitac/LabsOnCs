// Задана дата экзамена. С клавиатуры надо вводить другую дату, в случае, если дата раньше даты экзамена, -
// - вывести "осталось n дней", если уже прошел экзамен "прошло n дней", и если экзамен сегодня "сегодня экзамен!"

#if false
class Lab5_6
{
    static void Main()
    {
        DateTime exams = new DateTime(2026, 06, 15);

        Console.Write("Введите текущию дату в формате (ДД.ММ.ГГГГ): ");
        string input = Console.ReadLine();

        if (!DateTime.TryParseExact(input, "dd.MM.yyyy", null,
                System.Globalization.DateTimeStyles.None, out DateTime date))
        {
            Console.WriteLine("Дата невалидна!");
            return;
        }
        
        TimeSpan timeSpan = date - exams;
        if (date.Date == exams.Date)
        {
            Console.WriteLine("Сегодня экзамен!!!");
        }
        else if (date < exams)
        {
            Console.WriteLine("Осталось {0} дней", Math.Abs(timeSpan.Days));
        }
        else
        {
            Console.WriteLine("Прошло {0} дней", timeSpan.Days);
        }
    }
}
#endif