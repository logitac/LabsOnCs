class Lab2_1
{
    static void Main(string[] args)
    {
        Console.Write("Введите три числа: ");
        var stringInput = Console.ReadLine().Split(' ');
        int num1 = Convert.ToInt32(stringInput[0]);
        int num2 = Convert.ToInt32(stringInput[1]);
        int num3 = Convert.ToInt32(stringInput[2]);
        
        if(num1 > 0)
            Console.WriteLine($"{num1}^2 = {Math.Pow(num1, 2)}");
        else
            Console.WriteLine($"{num1}^4 = {Math.Pow(num1, 4)}");
    
        if(num2 > 0)
            Console.WriteLine($"{num2}^2 =  {Math.Pow(num2, 2)}");
        else
            Console.WriteLine($"{num2}^4 = {Math.Pow(num2, 4)}");
    
        if (num3 > 0)
            Console.WriteLine($"{num3}^2 = {Math.Pow(num3, 2)}");
        else
            Console.WriteLine($"{num3}^4 = {Math.Pow(num3, 4)}");
    }
}