// Ввести с консоли строку в формате ДД.ММ.ГГГГ. Проверьте является ли введенная строка валидной датой.

#if false
class Lab5_1
{
    static void Main()
    {
        Console.Write("Введите дату в формате (ДД.ММ.ГГГГ): ");
        string input = Console.ReadLine();
        
        if (DateTime.TryParseExact(input, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out _))
            Console.WriteLine("Дата валидна!");
        else
            Console.WriteLine("Дата невалидна!");
    }
}
#endif