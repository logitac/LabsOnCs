## Моё решение которое прошло все тесты:
[**Задача -> CodeWars**](https://www.codewars.com/kata/529eef7a9194e0cbc1000255/train/csharp)

### Условие:
Анаграмма является результатом перестановки букв слова для создания нового слова.
Примечание: анаграммы бесчувственны к случаю
Завершить функцию возврата true если два приведенных аргумента являются анаграммами друг друга; возврат false в противном случае.
Примеры
* "foefet" Это анаграмма "toffee"
* "Buckethead" Это анаграмма "DeathCubeK"

```
using System;

public class Kata
{
    public static bool IsAnagram(string a, string b)
    {
      char[] letters1 = a.ToLower().ToCharArray();
      char[] letters2 = b.ToLower().ToCharArray();
      
      if(letters1.Length != letters2.Length)
        return false;
      
      Array.Sort(letters1);
      Array.Sort(letters2);
      
      string sorted1 = new string(letters1);
      string sorted2 = new string(letters2);
      if(sorted1 == sorted2)
        return true;
      else
        return false;
      
    }
}
```