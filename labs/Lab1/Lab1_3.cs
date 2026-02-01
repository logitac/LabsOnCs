class Lab1_3
{
    static void Main(string[] args)
    {
        int a, b, res;
        
        Console.Write("Enter the first number: ");
        a = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the second number: ");
        b = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter result: ");
        res = Convert.ToInt32(Console.ReadLine());

        if (a * b == res)
        {
            Console.WriteLine("YES");
        }
        else
        {
            Console.WriteLine("NO");
        }
    }
}

// Ссылка на задачку: https://acmp.ru/index.asp?main=task&id_task=8