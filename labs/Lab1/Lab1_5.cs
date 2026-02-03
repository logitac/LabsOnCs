#if false
class Lab1_5
{
    static void Main(string[] args)
    {
        int num1, num2;
        Console.Write("Enter the first number: ");
        num1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the second number: ");
        num2 = Convert.ToInt32(Console.ReadLine());

        if (num1 > num2)
            Console.WriteLine(num1 + " > " + num2);
        else if (num1 < num2)
            Console.WriteLine(num1 + " < " + num2);
        else
            Console.WriteLine(num1 + " = " + num2);
    }
}
#endif
// Ссылка на задачку: https://acmp.ru/index.asp?main=task&id_task=25