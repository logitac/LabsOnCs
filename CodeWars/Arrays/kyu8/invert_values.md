## Моё решение которое прошло все тесты:
[**Задача -> CodeWars**](https://www.codewars.com/kata/5899dc03bc95b1bf1b0000ad/train/csharp)
```cs
using System.Linq;
namespace Solution
{
  public static class ArraysInversion
  {
    public static int[] InvertValues(int[] input)
    {
      if(input.Length == 0)
        return input;
      
      
      int[] newArray = new int[input.Length];
      for(int i = 0; i < input.Length; i++)
      {
          newArray[i] = input[i]*(-1);
      }
      
      return newArray;
    }
  }
}
```

## Лучшее решение

```cs
using System.Linq;
namespace Solution
{
  public static class ArraysInversion
  {
    public static int[] InvertValues(int[] input)
    {
      return input.Select(n => -n).ToArray();
    }
  }
}
```