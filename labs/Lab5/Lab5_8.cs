// Задан день и месяц рождения в формате dd.mm.
// Определите, сколько дней осталось/прошло с дня рождения. Если сегодня - день рождения, то вывести поздравление.

#if false
class Lab5_8
{
    static void Main()
    {
        Console.Write("Введите день и месяц рождения (ДД.ММ): ");
        string input = Console.ReadLine();

        if (!DateTime.TryParseExact(input, "dd.MM", null,
                System.Globalization.DateTimeStyles.None, out DateTime birthDayMonth))
        {
            Console.WriteLine("Неверный формат даты!");
            return;
        }

        DateTime today = DateTime.Today;

        if (birthDayMonth.Day == today.Day && birthDayMonth.Month == today.Month)
        {
            Console.WriteLine("🎂 С днём рождения! 🎉");
            return;
        }

        DateTime birthdayThisYear = new DateTime(today.Year, birthDayMonth.Month, birthDayMonth.Day);

        if (birthdayThisYear > today)
        {
            int daysLeft = (birthdayThisYear - today).Days;
            Console.WriteLine($"До дня рождения осталось {daysLeft} дн.");
        }
        else
        {
            DateTime birthdayNextYear = birthdayThisYear.AddYears(1);
            int daysLeft = (birthdayNextYear - today).Days;
            int daysPassed = (today - birthdayThisYear).Days;
            Console.WriteLine($"День рождения был {daysPassed} дн. назад. До следующего осталось {daysLeft} дн.");
        }
    }
}
#endif