//Петя и Вася часто играют в различные логические игры.
//Недавно Петя поведал Васе о новой игре «Быки и коровы» и теперь они играют в эту игру сутками.
//Суть игры очень проста: Петя загадывает четырехзначное число, состоящее из различных цифр.
//Вася отгадывает задуманное Петей число, перебирая возможные варианты.
//Каждый раз Вася предлагает вариант своего числа, а Петя делает Васе подсказку:
//сообщает количество быков и коров, после чего Вася с учетом подсказки продолжает отгадывание числа до тех пор, пока не отгадает.
//Быки – это количество цифр в предложенном Васей числе, совпадающих по значению и стоящих в правильной позиции в задуманном Петей числе.
//Коровы – количество цифр, совпадающих по значению, но находящихся в неверной позиции.
//Например, если Петя задумал число 5671, а Вася предложил вариант 7251, то число быков равно 1 (только цифра 1 на своем месте),
//а число коров равно 2 (только цифры 7 и 5 не на своих местах). Петя силен в математике, но даже он может ошибаться.
//Помогите Пете написать программу, которая бы по загаданному Петей и предложенному Васей числам сообщала количество быков и коров.


#if false
class Lab6_2
{
    static void Main(string[] args)
    {
        Random rand = new Random();
        int guessedNumber = rand.Next(1000, 10000);
        
        while (true)
        {
            Console.Write("> ");
            int number;
            if (!(Int32.TryParse(Console.ReadLine(), out number) && number >= 1000 && number <= 9999))
            {
                Console.WriteLine("Please enter a number between 1000 and 9999");
                continue;
            }
            
             (int bull, int cow) = CheckNumber(number, guessedNumber);
             Console.WriteLine($"Быков: {bull}");
             Console.WriteLine($"Коров: {cow}");

             if (bull == 4)
             {
                 Console.WriteLine($"Вы угадали! Загаданное число было: {guessedNumber}");
                 break;
             }
        }
    }

    static (int, int) CheckNumber(int number, int guessedNumber) // 5423 5984
    {
        string strNumber = number.ToString();
        string strGuessedNumber = guessedNumber.ToString();

        int bull = 0;
        int cow = 0;

        bool[] secretUsed = new bool[4];
        bool[] userUsed = new bool[4];
        
        for (int i = 0; i < 4; i++)
        {
            if (strNumber[i] == strGuessedNumber[i])
            {
                bull++;
                secretUsed[i] = true;
                userUsed[i] = true;
            }
        }
        
        for (int i = 0; i < 4; i++)
        {
            if (userUsed[i]) continue;

            for (int j = 0; j < 4; j++)
            {
                if (secretUsed[j]) continue;
            
                if (strNumber[i] == strGuessedNumber[j])
                {
                    cow++;
                    secretUsed[j] = true;
                    break;
                }
            }
        }
        
        return (bull, cow);
    }
}
#endif