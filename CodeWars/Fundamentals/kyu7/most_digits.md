## Моё решение которое прошло все тесты:
[**Задача -> CodeWars**](https://www.codewars.com/kata/58daa7617332e59593000006/train/csharp)

### Условие:
Найдите число с наибольшим количеством цифр.
Если два числа в массиве аргументов имеют одинаковое количество цифр, верните первое в массиве.


##### Алгоритм таков:
1. Перевести каждое число в массиве в строку.
2. Найти максимум цифр в строке с помощью функции **Length - 1**.
3. Сохранить в переменной первое вхождение такого числа.
4. Вернуть значение.

##### Решение кодом:
```
public class Kata
{
  public static int FindLongest(int[] number)
  {
    int maxDigits = 0;
    int resNumber = 0;
    
    for(int i = 0; i < number.Length; i++) {
      string str = number[i].ToString();
      
      if(maxDigits < str.Length - 1) {
        maxDigits = str.Length - 1;
        resNumber = number[i];
      }
    }
    
    return resNumber;
  }
}
```