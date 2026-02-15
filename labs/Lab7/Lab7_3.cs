#if false
class Lab7_3
{
    static void Main()
    {
        Console.Write("Введите строку: ");
        string? input = Console.ReadLine();
        
        int length = input?.Length ?? 0;
        Console.WriteLine($"Длина строки: {length}");
            
    }
}
#endif