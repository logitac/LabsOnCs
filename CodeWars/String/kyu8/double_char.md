## Моё решение которое прошло все тесты:
[**Задача -> CodeWars**](https://www.codewars.com/kata/56b1f01c247c01db92000076/train/csharp)
```cs
public class Kata
{
    public static string DoubleChar(string s)
    {
        string new_s = "";
        for(int i = 0; i < s.Length; i++) {
            new_s += s[i];
            new_s += s[i];
        }
    
        return new_s;
    }
}
```