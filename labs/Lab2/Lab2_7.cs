#if false
class Lab2_7
{
    static void Main()
    {
        Console.Write("Введите три числа через пробел: ");
        var stringInput = Console.ReadLine().Split();
        
        int a = int.Parse(stringInput[0]);
        int b = int.Parse(stringInput[1]);
        int c = int.Parse(stringInput[2]);
        
        
        int max = Math.Max(Math.Max(a, b), c);
        int min = Math.Min(Math.Min(a, b), c);
        
        
        int sum = max + min;
        
        Console.WriteLine($"Максимум: {max}");
        Console.WriteLine($"Минимум: {min}");
        Console.WriteLine($"Сумма: {sum}");
    }
}
#endif