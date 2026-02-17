using System;
using System.Threading;
using System.Threading.Tasks;

#if false
class AsyncMethod
{
    static void Main()
    {
        FactorialAsync();   

        Console.Write(
            "Введите число: ");

        int n = Int32.Parse(Console.ReadLine());

        Console.WriteLine(
            $"Квадрат числа равен {n * n}");
        Console.WriteLine("Конец метода Main");
    
        Console.Read();
        
    }
    static void Factorial()
    {
        int result = 1;
        for(int i = 1; i <= 6; i++)
        {
            result *= i;
        }
        Thread.Sleep(8000);
        Console.WriteLine(
            $"Факториал равен {result}");
    }
    
    static async void FactorialAsync()
    {
        
        Console.WriteLine(
            "Начало метода FactorialAsync");

            
        await Task.Run(()=>Factorial());

        Console.WriteLine(
            "Конец метода FactorialAsync");
    }
}
#endif