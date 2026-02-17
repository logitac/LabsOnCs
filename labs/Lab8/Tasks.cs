using System;
using System.Threading.Tasks;

#if false
class Tasks
{
    static void Main(string[] args)
    {
        FactorialAsync(5); 
        FactorialAsync(6);
        Console.WriteLine("Некоторая работа");
        Console.Read();
    }

    static void Factorial(int n)
    {
        int result = 1;
        for(int i = 1; i <= n; i++)
            result *= i;
        Console.WriteLine(result);
    }

    static async Task FactorialAsync(int n)
    {
        await Task.Run(() => Factorial(n));
    }
}
#endif