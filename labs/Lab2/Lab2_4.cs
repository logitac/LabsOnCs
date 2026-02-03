#if false
class Lab2_4
{
    static void Main(string[] args)
    {
        Console.Write("Введите два числа не равных друг другу: ");
        var stringInput = Console.ReadLine().Split(' ');
        
        int num1 = Convert.ToInt32(stringInput[0]);
        int num2 = Convert.ToInt32(stringInput[1]);
        
        if (num1 == num2)
        {
            Console.WriteLine("Числа равны друг другу!");
            return;
        }
    
        int halfSum = (num1 + num2) / 2;
        int doubleProduct = (num1 * num2) * 2;
    
        
        int result1, result2;
    
        if (num1 < num2)
        {
            result1 = halfSum;
            result2 = doubleProduct;
        }
        else
        {
            result1 = doubleProduct;
            result2 = halfSum;
        }
        
        Console.WriteLine($"Результат: {result1}, {result2}");
    }
}
#endif