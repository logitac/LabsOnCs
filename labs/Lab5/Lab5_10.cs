// Задан неупорядоченный список дат в формате ДД.ММ.ГГГГ,  найти ближайшую (к сегодняшнему дню) дату из списка.

#if false
class Lab5_10
{
    static void Main()
    {
        List<DateTime> listDateTime = new List<DateTime>();

        Console.WriteLine("Вводите время в формате (ДД.ММ.ГГГГ): ");
        Console.Write("> ");
        string input;
        while ((input = Console.ReadLine()) != "")
        {
            Console.Write("> ");
            if (!DateTime.TryParseExact(input, "dd.MM.yyyy", null, 
                    System.Globalization.DateTimeStyles.None, out DateTime result))
            {
                Console.WriteLine("Дата не валидна!");
                continue;
            }
            
            listDateTime.Add(result.Date);
        }
        
        DateTime today = DateTime.Today;
        DateTime nearDate = new DateTime();
        int minDaysDifference = int.MaxValue;
        foreach (DateTime date in listDateTime)
        {
            int daysDifference = Math.Abs((date - today).Days);
            if (daysDifference < minDaysDifference)
            {
                nearDate = date;
                minDaysDifference = daysDifference;
            }
        }

        Console.WriteLine("Ближайшая дата: {0}", nearDate.ToString("dd.MM.yyyy"));
    }
}
#endif