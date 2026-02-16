## Моё решение которое прошло все тесты:
[**Задача -> CodeWars**](https://www.codewars.com/kata/52fba66badcd10859f00097e/train/csharp)

### Условие: 
Тролли атакуют ваш раздел комментариев!
Общий способ справиться с этой ситуацией - удалить все гласные из комментариев троллей, нейтрализуя угрозу.
Ваша задача состоит в том, чтобы написать функцию, которая принимает строку и вернуть новую строку со всеми удаленными гласными.
Например, строка "Этот сайт для неудачников LOL!" Он стал бы «Всёй звездой LL!».
Примечание: для этого ката 'y' не считается гласным.

Короче, удалить все гласные в строке.
```cs
using System;

public static class Kata
{
  public static string Disemvowel(string str)
  {
    string vowel_letters = "AEIOUaeiou";
      
    string new_str = "";
    for(int i = 0; i < str.Length; i++) {
      bool isVowel = false;
      for(int j = 0; j < vowel_letters.Length; j++) {
        if(str[i] == vowel_letters[j]) {
          isVowel = true;
          break;
        }
      }
      if(!isVowel)
        new_str += str[i];
    }
    return new_str;
  }
}
```

## Лучшие решения (не мои естественно):
```
using System;
using System.Text.RegularExpressions;

public static class Kata
{
  public static string Disemvowel(string str)
  {
    return Regex.Replace(str,"[aeiou]", "", RegexOptions.IgnoreCase);
  }
}
```

```
using System;

public static class Kata
{
   public static string Disemvowel(string str)
  { 
    string[] vowels = {"a","e","i","o","u","A","E","I","O","U"}; 
    for (int i = 0; i < vowels.Length; i++)
  	{
  	  str = str.Replace(vowels[i],"");	
  	}
  	  	return str;
  	}
}
```