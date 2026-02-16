## Моё решение которое прошло все тесты:
[**Задача -> CodeWars**](https://www.codewars.com/kata/62a933d6d6deb7001093de16/train/csharp)

### Условие:
Слишком большое...

```cs
public class Kata 
{
  public static int GetTheVowels(string word) 
  {
    if(string.IsNullOrEmpty(word))
      return 0;
    
    int count = 0;
    int i = 0;
    string correctSequenceVowels = "aeiou";
    
    foreach(char c in word) {
      if(i == 5)
        i = 0;
      
      if(c == correctSequenceVowels[i]) {
        count++;
        i++;
      }
    }
    
    return count;
  }
}
```
P.S. Это считается лучшим решением этой задачи (возможно).

### Решение, которое предложила нейронка (более элигатная)
```
public class Kata 
{
    public static int GetTheVowels(string word) 
    {
        if(string.IsNullOrEmpty(word))
            return 0;
        
        int count = 0;
        int expectedIndex = 0;
        string vowels = "aeiou";
        
        foreach(char c in word) 
        {
            if(c == vowels[expectedIndex])
            {
                count++;
                expectedIndex = (expectedIndex + 1) % 5; // Циклический переход
            }
        }
        
        return count;
    }
}
```

