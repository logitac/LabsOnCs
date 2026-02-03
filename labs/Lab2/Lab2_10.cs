#if false
class Lab2_10
{
    static void Main(string[] args)
    {
        Console.Write("Введите три числа: ");
        var stringInput = Console.ReadLine().Split();
        int a = Convert.ToInt32(stringInput[0]);
        int b = Convert.ToInt32(stringInput[1]);
        int c = Convert.ToInt32(stringInput[2]);
        
        
        if (a + b <= c || a + c <= b || b + c <= a)
        {
            Console.WriteLine("NO");
            return;
        }
        
        Console.WriteLine("YES");
        
        if (a >= b && a >= c)
            Console.WriteLine(a*a < b*b + c*c ? "Остроугольный" : "Не остроугольный");
        else if (b >= a && b >= c)
            Console.WriteLine(b*b < a*a + c*c ? "Остроугольный" : "Не остроугольный");
        else
            Console.WriteLine(c*c < a*a + b*b ? "Остроугольный" : "Не остроугольный");
    }
}
#endif