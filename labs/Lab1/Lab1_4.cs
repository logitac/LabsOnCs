#if false
class Lab1_4
{
    static void Main(string[] args)
    {
        int num1, num2, num3, max, min, res;
        
        Console.Write("Enter the first number: ");
        num1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the second number: ");
        num2 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the third number: ");
        num3 = Convert.ToInt32(Console.ReadLine());
        
        // max
        if (num1 > num2)
        {
            if (num1 > num3)
                max = num1;
            else
                max = num3;
        }
        else
        {
            if (num2 > num3)
                max = num2;
            else
                max = num3;
        }

        // min
        if (num1 < num2)
        {
            if (num1 < num3) 
                min = num1;
            else
                min = num3;
        }
        else
        {
            if (num2 < num3)
                min = num2;
            else
                min = num3;
        }
        
        
        res = max - min;
        Console.WriteLine($"Difference = {res}");
    }
}
#endif
// Ссылка на задачку: https://acmp.ru/index.asp?main=task&id_task=21