#if false
class Lab7_4
{
    static void Main()
    {
        Console.Write("Введите выражение в виде (число1 {+, -, *, /} число2): ");

        try
        {
            string? userInput = Console.ReadLine();
            
            if (userInput == null)
                throw new ArgumentNullException(nameof(userInput), "Ввод не может быть null!");
            
            string[] input = userInput.Split(' ');
            
            if (input.Length != 3)
                throw new ArgumentException("Введите ровно 3 элемента через пробел!");
            
            if (!int.TryParse(input[0], out int num1))
                throw new FormatException($"'{input[0]}' - это не число!");
            
            if (!int.TryParse(input[2], out int num2))
                throw new FormatException($"'{input[2]}' - это не число!");
            
            string sign = input[1];
            int res;

            switch (sign)
            {
                case "+":
                    res = num1 + num2;
                    Console.WriteLine($"{num1} + {num2} = {res}");
                    break;
                case "-":
                    res = num1 - num2;
                    Console.WriteLine($"{num1} - {num2} = {res}");
                    break;
                case "*":
                    res = num1 * num2;
                    Console.WriteLine($"{num1} * {num2} = {res}");
                    break;
                case "/":
                    if (num2 == 0)
                        throw new DivideByZeroException("Деление на ноль запрещено!");
                    res = num1 / num2;
                    Console.WriteLine($"{num1} / {num2} = {res}");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(sign), 
                        $"Операция '{sign}' недоступна! Используйте +, -, *, /");
            }
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (ArgumentException ex)  
        {
            Console.WriteLine($"Ошибка ввода: {ex.Message}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Ошибка формата: {ex.Message}");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Ошибка вычисления: {ex.Message}");
        }
        catch (OverflowException ex)
        {
            Console.WriteLine($"Переполнение: {ex.Message}");
        }
    }
}
#endif