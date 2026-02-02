class Lab2_2
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите координаты двух точек: ");
        Console.Write("x1 = ");
        float x1 = float.Parse(Console.ReadLine());
        Console.Write("y1 = ");
        float y1 = float.Parse(Console.ReadLine());
        Console.Write("x2 = ");
        float x2 = float.Parse(Console.ReadLine());
        Console.Write("y2 = ");
        float y2 = float.Parse(Console.ReadLine());
    
        double d1 = Math.Pow(x1, 2) + Math.Pow(y1, 2);
        double d2 = Math.Pow(x2, 2) + Math.Pow(y2, 2);
        
        if(d1 < d2)
            Console.WriteLine($"{Math.Round(d1)} < {Math.Round(d2)}");
        else if(d1 > d2)
            Console.WriteLine($"{Math.Round(d1)} > {Math.Round(d2)}");
        else
            Console.WriteLine($"{Math.Round(d1)} = {Math.Round(d2)}");
    }
}