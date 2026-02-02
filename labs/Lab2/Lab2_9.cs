class Lab2_9
{
    static void Main(string[] args)
    {
        const double Ax = 0, Ay = 0;  
        const double Bx = 4, By = 0;  
        const double Cx = 0, Cy = 3;  
        
        
        Console.Write("Введите координаты точки D (x y): ");
        var stringInput = Console.ReadLine().Split();
        double Dx = double.Parse(stringInput[0]);
        double Dy = double.Parse(stringInput[1]);
        
        
        bool side1 = (Bx - Ax) * (Dy - Ay) - (By - Ay) * (Dx - Ax) >= 0;
        bool side2 = (Cx - Bx) * (Dy - By) - (Cy - By) * (Dx - Bx) >= 0;
        bool side3 = (Ax - Cx) * (Dy - Cy) - (Ay - Cy) * (Dx - Cx) >= 0;
        
        
        bool inside = (side1 == side2) && (side2 == side3);
        
        Console.WriteLine($"Точка D({Dx},{Dy}) {(inside ? "ВНУТРИ" : "СНАРУЖИ")} треугольника");
    }
}