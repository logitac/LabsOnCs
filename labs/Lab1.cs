class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите два целых числа через пробел: ");
        var inputString = Console.ReadLine();
        var stringParts = inputString.Split(' ');
        int A = Convert.ToInt32(stringParts[0]);
        int B = Convert.ToInt32(stringParts[1]);
        Console.WriteLine($"A + B = {A + B}");
    }
}

// Ссылка на задачку: https://acmp.ru/index.asp?main=task&id_task=1
