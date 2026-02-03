## Моё решение которое прошло все тесты:
[**Задача -> CodeWars**](https://www.codewars.com/kata/5a2be17aee1aaefe2a000151/train/csharp)
```
public static class Kata
{
  public static int ArrayPlusArray(int[] arr1, int[] arr2)
  {
    int sum = 0;
    
    for(int i = 0; i < arr1.Length; i++){
      sum += arr1[i];
    }
    
    for(int i = 0; i < arr2.Length; i++){
      sum += arr2[i];
    }
    
    return sum;
  }
}
```

## Другой способ (не моё решение)

```
public static class Kata
{
  public static int ArrayPlusArray(int[] arr1, int[] arr2)
  {
    return arr1.Sum() + arr2.Sum();
  }
}
```