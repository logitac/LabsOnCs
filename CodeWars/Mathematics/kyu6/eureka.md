## Моё решение которое прошло все тесты:
[**Задача -> CodeWars**](https://www.codewars.com/kata/5626b561280a42ecc50000d1/train/csharp)

##### Решил с подсказкой от нейронки. Подсказала, что можно число превратить в строку и дальше работать со строкой (теперь знаю про такой способ решения).
```cs
using System.Collections.Generic;
using System;

public class SumDigPower
{
    public static long[] SumDigPow(long a, long b)
    {
        List<long> lst = new List<long>();
        long current = a;

        while(current <= b) {
            string num = current.ToString();
            long sum = 0;
        
            for(int i = 0; i < num.Length; i++) {
            long n = Int64.Parse(num[i].ToString());;
            sum += Convert.ToInt64(Math.Pow(n, i+1));
            }
        
            if(sum == current)
            lst.Add(sum);
        
            current++;
        }
      
      
        return lst.ToArray();
    }
}
```
