## Моё решение которое прошло все тесты:
[**Задача -> CodeWars**](https://www.codewars.com/kata/5b76a34ff71e5de9db0000f2/train/csharp)

### Условие:
В этой Кате вам будет предоставлен ряд случаев, когда звучит сигнал тревоги. 
Ваша задача будет заключаться в определении максимального временного интервала между сигналами тревоги. 
Каждая сигнализация начинает звонить в начале соответствующей минуты и звонит ровно одну минуту. 
Времена в массиве не в хронологическом порядке. Игнорируйте дубликаты времени, если таковые имеются.

Примеры:

["14:51"] --> "23:59"

Если будильник звучит сейчас, он не будет звучать еще 23 часа 59 минут.

["23:00","04:22","18:05","06:24"] --> "11:40"

Звучит сигнал тревоги 4 раза в день. Максимальный интервал, который не будет звучать, составляет 11 часов 40 минут.

```
using System.Collections.Generic;
using System;
using System.Linq;

public class Solution
{
    public static string solve(string [] arr)
    {
      if(arr.Length == 1)
        return "23:59";
      
      List<int> minutes = new List<int>();
      HashSet<int> uniqueMinutes = new HashSet<int>();
      
      for(int i = 0; i < arr.Length; i++) {
        DateTime time = Convert.ToDateTime(arr[i]);
        int minutesOfTime = time.Hour * 60 + time.Minute;
        
        uniqueMinutes.Add(minutesOfTime);
      }
      
      minutes = uniqueMinutes.ToList();
      minutes.Sort();
      
      List<int> intervals = new List<int>();
      
      for(int i = 0; i < minutes.Count - 1; i++) {
        int interval = minutes[i+1] - minutes[i];
        intervals.Add(interval);
      }
      
      int lastToFirst = (24 * 60 - minutes[minutes.Count - 1]) + minutes[0];
      intervals.Add(lastToFirst);
      
      int maxi = intervals.Max();
      
      int hours = maxi / 60;
      int mins = maxi % 60 - 1;
        
      return $"{hours:D2}:{mins:D2}";
    }
}
```

## !!! Решено с нейронкой !!!