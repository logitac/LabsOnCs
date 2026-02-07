#if true
class Lab4_6
{
    static void Main()
    {
        Console.Write("Введите первое имя: ");
        string name1 = Console.ReadLine();
        
        Console.Write("Введите второе имя: ");
        string name2 = Console.ReadLine();
        
        char[] letters1 = name1.Replace(" ", "").ToLower().ToCharArray();
        char[] letters2 = name2.Replace(" ", "").ToLower().ToCharArray();
        
        if (letters1.Length != letters2.Length)
        {
            Console.WriteLine("Нет, нельзя");
            return;
        }
        
        Array.Sort(letters1);
        Array.Sort(letters2);
        
        string sorted1 = new string(letters1);
        string sorted2 = new string(letters2);
        bool isAnagram = sorted1 == sorted2;
        
        if (isAnagram)
        {
            Console.WriteLine("Да, можно");
        }
        else
        {
            Console.WriteLine("Нет, нельзя");
        }
    }
}
#endif

// Пример вывода программы:

// Введите первое имя: Tom Marvolo Riddle
// Введите второе имя: I am Lord Voldemort
// Да, можно

// Введите первое имя: Tom Marvolo Riddle
// Введите второе имя: I am Lord VoldemorZ
// Нет, нельзя