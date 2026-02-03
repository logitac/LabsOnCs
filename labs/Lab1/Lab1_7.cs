#if false
class Lab1_7
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите число:");
        int k =  int.Parse(Console.ReadLine());
        
        Console.WriteLine($"Введите {k} пар чисел n m:");

        for (int i = 0; i < k; i++)
        {
            var input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);
            
            long d = 19L * m + ((n + 239L) * (n + 366L)) / 2;
            Console.WriteLine($"Автомат {i + 1}: d = {d}");
        }
    }
}
#endif
// Ссылка на задачку: https://acmp.ru/index.asp?main=task&id_task=35