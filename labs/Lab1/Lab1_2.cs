#if false
class Lab1_2
{
    static void Main()
    {
        byte number; int result = 0;
        
        Console.Write("Enter a number: ");
        number = byte.Parse(Console.ReadLine());
        
        if (number < 1 || number > 8)
        {
            Console.WriteLine("Invalid input");
            return;
        }
        
        result = (((number * 10) + 9) * 10) + (9 - number);
        Console.WriteLine(result);
    }
}
#endif
// Ссылка на задачу: https://acmp.ru/index.asp?main=solution&id_task=4