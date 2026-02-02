class Lab2_8
{
    static void Main(string[] args)
    {
        Console.Write("Введите координаты точки (x y): ");
        var stringInput = Console.ReadLine().Split();
        double x = double.Parse(stringInput[0]);
        double y = double.Parse(stringInput[1]);
        
        Console.Write("Введите радиус окружности: ");
        double radius = double.Parse(Console.ReadLine());
        
        
        double distance = Math.Sqrt(x * x + y * y);
        
        if (distance <= radius)
            Console.WriteLine($"Точка ({x}, {y}) ВХОДИТ в окружность радиуса {radius}");
        else
            Console.WriteLine($"Точка ({x}, {y}) НЕ входит в окружность радиуса {radius}");
    }
}