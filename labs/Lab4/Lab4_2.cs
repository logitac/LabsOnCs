#if false
class Lab4_2
{
    static void Main()
    {
        const string symbols = "АВСЕНКМОРТХYABCEHKMOPTX";
        
        string numberBus;
        int[] letterPositions = { 0, 4, 5 };
        Console.WriteLine("Вводите номера автобусов: ");
        while ((numberBus = Console.ReadLine()) != "")
        {
            bool flag = true;
            if (numberBus.Length != 6)
            {
                flag = false;
                goto isValid;
            }

            for (int i = 1; i <= 3; i++)
            {
                if (!char.IsDigit(numberBus[i]))
                    flag = false;
            }

            foreach (var letterPosition in letterPositions)
            {
                if (!symbols.Contains(numberBus[letterPosition]))
                    flag = false;
            }
            
            isValid:
            if (flag)
                Console.WriteLine("Да");
            else
                Console.WriteLine("Нет");
            
        }
    }
}
#endif

// Пример вывода программы:

// Вводите номера автобусов:
// P204BT
// Да
// X182YZ
// Нет