#if false
class Lab2_6
{
    static void Main(string[] args)
    {
        Console.Write("Введите дату (день месяц год): ");
        var stringInput = Console.ReadLine().Split(' ');
        int day = int.Parse(stringInput[0]);
        int month = int.Parse(stringInput[1]);
        int year = int.Parse(stringInput[2]);
    
        if (day >= 1 && day <= 31 && month >= 1 && month <= 12)
        {
            Console.WriteLine($"{day:00}:{month:00}:{year}");
        }
        else
        {
            Console.WriteLine("Некорректный ввод!");
        }
    }
}
#endif