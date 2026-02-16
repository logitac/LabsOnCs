## Моё решение которое прошло все тесты:
[**Задача -> CodeWars**](https://www.codewars.com/kata/5556282156230d0e5e000089/train/csharp)
```cs
public class Converter
{
  public string dnaToRna(string dna)
  {
    string rna = "";
      
    foreach(char ch in dna) {
      if(ch != 'T')
        rna += ch;
      else
        rna += "U";
    }
    
    return rna;
  }
}
```

## Лучшее решение:

```
public class Converter
{
  public string dnaToRna(string dna)
  {
    return dna.Replace('T', 'U');
  }
}
```