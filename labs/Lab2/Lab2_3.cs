#if false
class Lab2_3
{
    static void Main(string[] args)
    {
        Console.Write("Введите два угла треугольника в градусах: ");
        var stringInput = Console.ReadLine().Split(' ');
        int angle1 = Convert.ToInt32(stringInput[0]);
        int angle2 = Convert.ToInt32(stringInput[1]);
        
        int angle3 = 180 - angle1 - angle2;
        
    
        if (angle1 > 0 && angle2 > 0 && angle3 > 0)
            if (angle1 == 90 || angle2 == 90 || angle3 == 90)
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
        else
            Console.WriteLine("Треугольник не существует");
        
    }
}
#endif