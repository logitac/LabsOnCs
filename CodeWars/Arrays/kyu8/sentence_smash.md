## Моё решение которое прошло все тесты:
[**Задача -> CodeWars**](https://www.codewars.com/kata/53dc23c68a0c93699800041d/train/csharp)
```
public class Kata
{
    public static string Smash(string[] words)
    {
        string str = "";
    
        foreach(string s in words)
        {
            str += str.Length == 0 ? s : " " + s;    
        }
    
        return str;
    }
}
```

## Лучшее решение:


```
public class Kata
{
  public static string Smash(string[] words)
  {
    return string.Join(" ", words);
  }
}
```