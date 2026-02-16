## Моё решение которое прошло все тесты:
[**Задача -> CodeWars**](https://www.codewars.com/kata/5259b20d6021e9e14c0010d4/train/csharp)

### Условие:
Завершите функцию, которая принимает параметр струны, и переворачивает каждое слово в строке. Все пробелы в строке должны быть сохранены.
Примеры:
* "This is an example!" ==> "sihT si na !elpmaxe"
* "double  spaces"      ==> "elbuod  secaps"
```cs
using System;

public static class Kata
{
  public static string ReverseWords(string str)
  {
    string reverse_str = "";
    
    int start = 0;
    while (start < str.Length)
    {
        int end = start;
        while (end < str.Length && str[end] != ' ')
            end++;
            
        for (int j = end - 1; j >= start; j--)
            reverse_str += str[j];
            
        if (end < str.Length)
            reverse_str += " ";
            
        start = end + 1;
    }
    
    return reverse_str;
  }
}
```