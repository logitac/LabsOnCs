## Моё решение которое прошло все тесты:
[**Задача -> CodeWars**](https://www.codewars.com/kata/6411b91a5e71b915d237332d/train/csharp)

### Условие:
Напишите функцию, которая принимает строку скобок и определяет, является ли порядок скобок действительным. 
Функция должна вернуться true если строка действительна, и false если это недействительно.
Примеры:

"()"              ⇒  true
")(()))"          ⇒  false
"("               ⇒  false
"(())((()())())"  ⇒  true


```cs
public class Kata 
{
  public static bool ValidParentheses(string str) 
  {
    int count = 0;
    
    for(int i = 0; i < str.Length; i++) {
      if(str[i] == '(') {
        count++;
      }
      else
        count--;
      
      if(count < 0)
        return false;
    }
    
    if(count == 0)
      return true;
    else
      return false;
  }
}
```
Полностью сам решил задачку!!!!