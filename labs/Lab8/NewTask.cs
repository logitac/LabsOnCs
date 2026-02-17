#if false
class NewTask
{
    static void Main()
    {
        Task task = new Task(() =>
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Секунда {i}");
                Thread.Sleep(1000);
            }
        });
        
        Console.WriteLine("Задача создана, но ещё не запущена");
        Console.WriteLine("Нажмите Enter, чтобы запустить задачу...");
        Console.ReadLine();
        
        
        task.Start();
        
        Console.WriteLine("Задача запущена!");
        Console.ReadLine();
    }
}
#endif