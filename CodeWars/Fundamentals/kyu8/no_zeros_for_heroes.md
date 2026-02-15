## Моё решение которое прошло все тесты:
[**Задача -> CodeWars**](https://www.codewars.com/kata/570a6a46455d08ff8d001002/train/csharp)

### Условие:
Цифры, заканчивающиеся с нулями, скучны.
Они могут быть веселыми в вашем мире, но не здесь.
Избавьтесь от них. Только конечные.

1450   -> 145

960000 -> 96

1050   -> 105

-1050  -> -105

0      -> 0

##### Алгоритм таков:
1. Делить число до тех пор, пока не будет равен 
цифре отличающийся от нуля или пока само число не будет равно нулю

##### Решение кодом:
```
using System;

public class NoBoring 
{
    public static int NoBoringZeros(int n) 
    {
      if(n == 0)
        return 0;
      
      string strN = n.ToString();
      int len = strN.Length - 1;
      while(strN[len] == '0') {
        n /= 10;
        strN = n.ToString();
        len--;
      }
      
      return n;
    }
}
```

Здесь я сильно усложнил решение, это задачку можно решить намного проще, 
но у меня получилось так.

##### Вот альтернативное решение, намного лучше, чем моё:
```
using System;

public class NoBoring 
{
    public static int NoBoringZeros(int n) 
    {
        while (n != 0 && n % 10 == 0)
            n /= 10;
            
        return n;
    }
}
```
##### Или можно по другому с использованием встроенных функций:
```
using System;

public class NoBoring 
{
    public static int NoBoringZeros(int n) 
    {        
          return (n == 0) ? 0 : Convert.ToInt32(n.ToString().TrimEnd('0'));
    }
}
```
