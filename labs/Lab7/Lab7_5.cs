#if false
class Lab7_5
{
    static void Main()
    {
        Console.Write("Введите индекс элемента которого вы хотите достать: ");
        string[] fruits = { "яблоко", "банан", "апельсин", null, "груша" };

        try
        {
            int index;
            if (!int.TryParse(Console.ReadLine(), out index))
                throw new FormatException("Нужно ввести число!");
            if (!(index >= 0 && index < fruits.Length))
                throw new IndexOutOfRangeException($"Индекс должен быть в пределах от 0 до {fruits.Length - 1}");
            if (fruits[index] == null)
                throw new NullReferenceException("Пусто");
            else
                Console.WriteLine($"Ваш элемент: {fruits[index]}");

        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
#endif