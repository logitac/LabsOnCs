## Моё решение которое прошло все тесты:
[**Задача -> CodeWars**](https://www.codewars.com/kata/5b077ebdaf15be5c7f000077/train/csharp)
```cs
public static class Kata
{
    public static string CountSheep(int n)
    {
        string result = "";
        for (int i = 1; i <= n; i++)
        {
            result += $"{i} sheep...";
        }
        return result;
    }
}
```