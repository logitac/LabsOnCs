## Моё решение которое прошло все тесты:
[**Задача -> CodeWars**](https://www.codewars.com/kata/56786a687e9a88d1cf00005d/train/csharp)

### Условие:
Вам будет дано слово. Ваша работа будет заключаться в том, чтобы убедиться, что каждый персонаж в этом слове имеет одинаковое количество случаев. 
Вы вернетесь true если это действительно, или false Если это не так.
Для этого ката заглавные буквы считаются такими же, как и строчные буквы. Таким образом: "A" == "a"
Вход представляет собой строку (без пробелов), содержащую [a-z],[A-Z],[0-9]и общих символов. Длина будет 0 < length < 100.
Примеры: 

'abcabc' Это действительное слово, потому что "a" Появляется дважды, "b" появляется дважды, и "c" Появляется дважды.
"abcabcd" Не является действительным словом, потому что "a" Появляется дважды, "b" Появляется дважды, "c" Появляется дважды, но "d" Появляется только один раз!
"123abc!" Это правильное слово, потому что все персонажи появляются только один раз в слове.


### Это не моё решение, его я решил с помощью нейронки, но я что-то совсем долго тупил над этой задачкой. Аж обидно.
```cs
using System.Collections.Generic;

public class Kata
{
    public static bool ValidateWord(string s)
    {
      if(string.IsNullOrEmpty(s))
        return true;
      
      string lower_s = s.ToLower();
      
      Dictionary<char, int> charCount = new Dictionary<char, int>();
      
      foreach(char c in lower_s) {
        if(charCount.ContainsKey(c))
          charCount[c]++;
        else
          charCount[c] = 1;
      }
      
      int firstCount = charCount[lower_s[0]];
      
      foreach(int count in charCount.Values)
        if(count != firstCount)
          return false;
      
      return true;
    }
}
```