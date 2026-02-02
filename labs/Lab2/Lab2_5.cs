class Lab2_5
{
    static void Main(string[] args)
    {
        Console.Write("Введите координаты точки (x y): ");
        var stringInput = Console.ReadLine().Split();
        
        double x = double.Parse(stringInput[0]);
        double y = double.Parse(stringInput[1]);
        
        Console.Write($"Точка ({x}, {y}) находится: ");
        
        if (x == 0 && y == 0)
            Console.WriteLine("в начале координат (0, 0)");
        else if (x == 0)
            Console.WriteLine("на оси Y");
        else if (y == 0)
            Console.WriteLine("на оси X");
        else if (x > 0 && y > 0)
            Console.WriteLine("в I четверти");
        else if (x < 0 && y > 0)
            Console.WriteLine("во II четверти");
        else if (x < 0 && y < 0)
            Console.WriteLine("в III четверти");
        else // x > 0 && y < 0
            Console.WriteLine("в IV четверти");
    }
}