#if false
class Lab7_1
{
    static void Main()
    {
        Console.Write("Введите два числа через пробел: ");
        var input = Console.ReadLine().Split(' ');
        int num1 = int.Parse(input[0]);
        int num2 = int.Parse(input[1]);

        try
        {
            int res = num1 / num2;
            Console.WriteLine(res);
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Деление на ноль запрещено!");
        }
    }
}
#endif