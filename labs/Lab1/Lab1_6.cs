#if false
class Lab1_6
{
    static void Main()
    {
        byte num1, num2;
        const byte max = 10;
        
        Console.Write("Enter how many cans Harry shot: ");
        num1 = Convert.ToByte(Console.ReadLine());
        Console.Write("Enter how many cans Larry shot: ");
        num2 = Convert.ToByte(Console.ReadLine());
        
        Console.WriteLine($"Harry didn't get shot = {max - num1}. Larry didn't get shot = {max - num2}");
    }
}
#endif
// Ссылка на задачку: https://acmp.ru/index.asp?main=task&id_task=25