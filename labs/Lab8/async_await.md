## Aсинхронное программирование. Асинхронные методы, async и await

Асинхронность позволяет вынести отдельные задачи из основного потока в специальные асинхронные методы или блоки кода. 
Особенно это актуально в графических программах, где продолжительные задачи могу блокировать интерфейс пользователя. 
И чтобы этого не произошло, нужно задействовать асинхронность. 
Также асинхронность несет выгоды в веб-приложениях при обработке запросов от пользователей, при обращении к базам данных или сетевым 
ресурсам. При больших запросах к базе данных асинхронный метод просто "уснёт" на время, пока не получит данные от БД, 
а основной поток сможет продолжить свою работу. В синхронном же приложении, если бы код получения данных находился в основном потоке, 
этот поток просто бы блокировался на время получения данных.

Ключевыми для работы с асинхронными вызовами в C# являются два ключевых слова: **async** и **await**, цель которых - 
упростить написание асинхронного кода. Они используются вместе для создания асинхронного метода.

Асинхронный метод обладает следующими признаками:

* В заголовке метода используется модификатор **async**
* Метод содержит одно или несколько выражений **await**
* В качестве возвращаемого типа используется один из следующих:
  * `void`
  * `Task`
  * `Task<T>`
  * `ValueTask<T>`

Асинхронный метод, как и обычный, может использовать любое количество параметров или не использовать их вообще. 
Однако асинхронный метод не может определять параметры с модификаторами **out** и **ref**.

Также стоит отметить, что слово **async**, которое указывается в определении метода, не делает автоматически метод асинхронным. 
Оно лишь указывает, что данный метод **может** содержать одно или несколько выражений **await**.

Рассмотрим пример [_асинхронного метода_](https://github.com/logitac/LabsOnCs/tree/master/labs/Lab8/AsyncMethod.cs):
```csharp
using System;
using System.Threading;
using System.Threading.Tasks;

// вызов асинхронного метода 
FactorialAsync();   

Console.Write(
    "Введите число: ");

int n = Int32.Parse(Console.ReadLine());

Console.WriteLine(
    $"Квадрат числа равен {n * n}");
    
Console.Read();


static void Factorial()
{
    int result = 1;
    for(int i = 1; i <= 6; i++)
    {
        result *= i;
    }
    Thread.Sleep(8000);
    Console.WriteLine(
        $"Факториал равен {result}");
}

// определение асинхронного метода
static async void FactorialAsync()
{
    // выполняется синхронно
    Console.WriteLine(
        "Начало метода FactorialAsync");

    // выполняется асинхронно     
    await Task.Run(()=>Factorial());

    Console.WriteLine(
        "Конец метода FactorialAsync");
}
```

Посмотрим, какой у программы будет консольный вывод:
```
Начало метода FactorialAsync
Введите число: 7
Квадрат числа равен 49
Конец метода Main
Факториал равен 720
Окончание метода FactorialAsync
```

Разберем поэтапно, что здесь происходит:
* Запускается метод **_Main_**, в котором вызывается асинхронный метод **_FactorialAsync_**.
* Метод **_FactorialAsync_** начинает выполняться синхронно вплоть до выражения **await**.
* Выражение **await** запускает асинхронную задачу `Task.Run(()=>Factorial())`
* Пока выполняется асинхронная задача `Task.Run(()=>Factorial())` (а она может выполняться довольно продожительное время), 
выполнение кода возвращается в вызывающий метод - то есть в метод Main. 
В методе Main нам будет предложено ввести число для вычисления квадрата числа.\
В этом и преимущество асинхронных методов - асинхронная задача, которая может выполняться довольно долгое время, 
не блокирует метод Main, и мы можем продолжать работу с ним, например, вводить и обрабатывать данные.
* Когда асинхронная задача завершила свое выполнение (в случае выше - подсчитала факториал числа), 
продолжает работу асинхронный метод **_FactorialAsync_**, который вызвал асинхронную задачу.

Функция факториала, возможно, представляет не самый показательный пример, 
так как в реальности в данном случае нет смысла делать ее асинхронной. 
Но рассмотрим другой пример - [_чтение-запись файла_](https://github.com/logitac/LabsOnCs/tree/master/labs/Lab8/ReadWriteAsync.cs):

```csharp
using System;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
 
ReadWriteAsync();
    
Console.WriteLine("Некоторая работа");
Console.Read();


static async void ReadWriteAsync()
{
    string s = "Hello world! One step at a time";

    // hello.txt - файл, который будет записываться и считываться
    using (StreamWriter writer = new StreamWriter("hello.txt", false))
    {
        // асинхронная запись в файл
        await writer.WriteLineAsync(s);  
    }
    using (StreamReader reader = new StreamReader("hello.txt"))
    {
        // асинхронное чтение из файла
        string result = await reader.ReadToEndAsync();  
        Console.WriteLine(result);
    }
} 
```

Асинхронный метод **_ReadWriteAsync_** выполняет запись в файл некоторой строки и затем считывает записанный файл. 
Подобные операции могут занимать продолжительное время, особенно при больших объемах данных, 
поэтому такие операции лучше делать асинхронными.

Далее в методе Main вызывается асинхронный метод **_ReadWriteAsync_**:
```cs
ReadWriteAsync();
            
Console.WriteLine("Некоторая работа");
Console.Read();
```

И опять же, когда выполнение в методе **_ReadWriteAsync_** доходит до первого выражения **await**, 
управление возвращается в метод **_Main_**, и мы можем продолжать с ним работу. 
Запись в файл и считывание файла будут производиться параллельно и не будут блокировать работу метода **_Main_**.

### Определение асинхронной операции

Как выше уже было сказано, фреймворк .NET имеет много встроенных методов, которые представляют асинхронную операцию. 
Они заканчиваются на суффикс **_Async_**. И перед вызывами подобных методов мы можем указывать оператор **await**. Например:

```csharp
StreamWriter writer = new StreamWriter("hello.txt", false);
// асинхронная запись в файл
await writer.WriteLineAsync("Hello");
```
Либо мы сами можем определить асинхронную операцию, используя метод `Task.Run()`:
```csharp
static void Factorial()
{
    int result = 1;
    for (int i = 1; i <= 6; i++)
    {
        result *= i;
    }
    Thread.Sleep(8000);
    Console.WriteLine($"Факториал равен {result}");
}
// определение асинхронного метода
static async void FactorialAsync()
{
    // вызов асинхронной операции
    await Task.Run(()=>Factorial()); 
}
```
Можно определить асинхронную операцию с помощью лямбда-выражения:
```csharp
static async void FactorialAsync()
{
    await Task.Run(() =>
    {
        int result = 1;
        for (int i = 1; i <= 6; i++)
        {
            result *= i;
        }
        Thread.Sleep(8000);
        Console.WriteLine($"Факториал равен {result}");
    });
}
```

### Передача параметров в асинхронную операцию
Выше вычислялся факториал `6`, но, допустим, мы хотим вычислять факториалы разных чисел:
```csharp
using System;
using System.Threading;
using System.Threading.Tasks;
 

FactorialAsync(5);
FactorialAsync(6);
Console.WriteLine("Некоторая работа");
Console.Read();


static void Factorial(int n)
{
    int result = 1;
    for (int i = 1; i <= n; i++)
    {
        result *= i;
    }
    Thread.Sleep(5000);
    Console.WriteLine($"Факториал равен {result}");
}
// определение асинхронного метода
static async void FactorialAsync(int n)
{
    await Task.Run(()=>Factorial(n));
}
```

### Получение результата из асинхронной операции
Асинхронная операция может возвращать некоторый результат, получить который мы можем так же, как и при вызове обычного метода:
```csharp
using System;
using System.Threading;
using System.Threading.Tasks;
 

FactorialAsync(5);
FactorialAsync(6);
Console.Read();


static int Factorial(int n)
{
    int result = 1;
    for (int i = 1; i <= n; i++)
    {
        result *= i;
    }
    return result;
}
// определение асинхронного метода
static async void FactorialAsync(int n)
{
    int x = await Task.Run(()=>Factorial(n));
    Console.WriteLine($"Факториал равен {x}");
}
```

Метод **_Factorial_** возвращает значение типа **int**, это значение мы можем получить, 
просто присвоив результат асинхронной операции переменной данного типа: `int x = await Task.Run(()=>Factorial(n))`;

### Возвращение результата из асинхронного метода
В качестве возвращаемого типа в асинхронном методе должны использоваться типы `void`, `Task`, `Task<T>` или `ValueTask<T>`

**void**

При использовании ключевого слова void асинхронный метод ничего не возвращает:
```csharp
static void Factorial(int n)
{
    int result = 1;
    for (int i = 1; i <= n; i++)
    {
        result *= i;
    }
    Console.WriteLine($"Факториал равен {result}");
}
// определение асинхронного метода
static async void FactorialAsync(int n)
{
    await Task.Run(()=>Factorial(n));
}
```

[**Task**](https://github.com/logitac/LabsOnCs/tree/master/labs/Lab8/Tasks.cs)

Возвращение объекта типа **Task**:
```csharp
using System;
using System.Threading.Tasks;

FactorialAsync(5);
FactorialAsync(6);
Console.WriteLine("Некоторая работа");
Console.Read();

static void Factorial(int n)
{
    int result = 1;
    for (int i = 1; i <= n; i++)
    {
        result *= i;
    }
    Console.WriteLine($"Факториал равен {result}");
}
    
// определение асинхронного метода
static async Task FactorialAsync(int n)
{
    await Task.Run(()=>Factorial(n));
}
```
Формально метод FactorialAsync не использует оператор return для возвращения результата. 
Однако если в асинхронном методе выполняется в выражении await асинхронная операция, то мы можем возвращать из метода объект Task.

#### [Task\<T\>](https://github.com/logitac/LabsOnCs/tree/master/labs/Lab8/TaskT.cs)

Метод может возвращать некоторое значение. 
Тогда возвращаемое значение оборачивается в объект **Task**, а возвращаемым типом является `Task<T>`:
```csharp
using System;
using System.Threading.Tasks;

int n1 = await FactorialAsync(5);
int n2 = await FactorialAsync(6);
Console.WriteLine($"n1={n1}  n2={n2}");
Console.Read();

static int Factorial(int n)
{
    int result = 1;
    for (int i = 1; i <= n; i++)
    {
        result *= i;
    }
    return result;
}
// определение асинхронного метода
static async Task<int> FactorialAsync(int n)
{
    return await Task.Run(()=>Factorial(n));
}
```

Чтобы получить результат асинхронного метода в методе Main, который тоже определен как асинхронный, 
применяем оператор await при вызове FactorialAsync.

#### 'ValueTask<T>'
Использование типа `ValueTask<T>` во многом аналогично применению `Task<T>` за исключением некоторых различий в работе с памятью, 
поскольку **ValueTask** - структура, а **Task** - класс. По умолчанию тип ValueTask недоступен, и чтобы использовать его, 
вначале надо установить через **NuGet** пакет `System.Threading.Tasks.Extensions`.

### Последовательный и параллельный вызов асинхронных операций

Асинхронный метод может содержать множество выражений **await**. Когда система встречает в блоке кода оператор **await**, 
то выполнение в асинхронном методе останавливается, пока не завершится асинхронная задача. 
После завершения задачи управление переходит к следующему оператору **await** и так далее. 
Это позволяет вызывать асинхронные задачи последовательно в определенном порядке. Например:
```csharp
using System;
using System.Threading.Tasks;

FactorialAsync();
Console.Read();

static void Factorial(int n)
{
    int result = 1;
    for (int i = 1; i <= n; i++)
    {
        result *= i;
    }
    Console.WriteLine($"Факториал числа {n} равен {result}");
}
// определение асинхронного метода
static async void FactorialAsync()
{
    await Task.Run(() => Factorial(4));
    await Task.Run(() => Factorial(3));
    await Task.Run(() => Factorial(5));
}
```
Консольный вывод данной программы:
```
Факториал числа 4 равен 24
Факториал числа 3 равен 6
Факториал числа 5 равен 120
```
То есть мы видим, что факториалы вычисляются последовательно. И в данном случае вывод строго детерминирован.

Нередко такая последовательность бывает необходима, если одна задача зависит от результатов другой.

Однако не всегда существует подобная зависимость между задачами. В этом случае мы можем запустить все задачи параллельно и 
через метод **_Task.WhenAll_** отследить их завершение. Например, изменим метод **_FactorialAsync_**:
```csharp
static async void FactorialAsync()
{
    Task t1 = Task.Run(() => Factorial(4));
    Task t2 = Task.Run(() => Factorial(3));
    Task t3 = Task.Run(() => Factorial(5));
    await Task.WhenAll(new[] { t1, t2, t3 });
}
```
Вначале запускаются три задачи. Затем **_Task.WhenAll_** создает новую задачу, которая будет автоматически выполнена после выполнения 
всех предоставленных задач, то есть задач `t1`, `t2`, `t3`. А с помощью оператора **await** ожидаем ее завершения.

В итоге все три задачи теперь будут запускаться параллельно, однако вызывающий метод FactorialAsync благодаря оператору await 
все равно будет ожидать, пока они все не завершатся. И в этом случае вывод программы не детерминирован. Например, он может быть следующим:
```
Факториал числа 5 равен 120
Факториал числа 4 равен 24
Факториал числа 3 равен 6
```
И если задача возвращает какое-нибудь значение, то это значение потом можно получить с помощью свойства Result.

### Обработка ошибок в асинхронных методах
Обработка ошибок в асинхронных методах, использующих ключевые слова **async** и **await**, имеет свои особенности.

Для обработки ошибок выражение **await** помещается в блок **try**:
```csharp
using System;
using System.Threading;
using System.Threading.Tasks;
 

FactorialAsync(-4);
FactorialAsync(6);
Console.Read();

static void Factorial(int n)
{
    if (n < 1)
        throw new Exception($"{n} : число не должно быть меньше 1");
    int result = 1;
    for (int i = 1; i <= n; i++)
    {
        result *= i;
    }
    Console.WriteLine($"Факториал числа {n} равен {result}");
}
    
static async void FactorialAsync(int n)
{
    try
    {
        await Task.Run(() => Factorial(n));
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
```
В методе Main вызывается асинхронный метод с передачей ему отрицательного числа: `FactorialAsync(-4)`, что привет к генерации исключения. 
Однако программа не остановит аварийно свою работу, а обработает исключение и продолжит дальнейшие вычисления.

#### Исследование исключения

При возникновении ошибки у объекта **Task**, представляющего асинхронную задачу, в которой произошла ошибка, 
свойство **_IsFaulted_** имеет значение **true**. Кроме того, свойство **_Exception_** объекта **Task** содержит всю информацию об ошибке. 
Чтобы проинспектировать свойство, изменим метод **_FactorialAsync_** следующим образом:
```csharp
static async void FactorialAsync(int n)
{
    Task task = null;
    try
    {
        task = Task.Run(()=>Factorial(n));
        await task;
    }
    catch (Exception ex)
    {
        Console.WriteLine(task.Exception.InnerException.Message);
        Console.WriteLine($"IsFaulted: {task.IsFaulted}");
    }
}
```
И если мы передадим в метод число `-1`, то `task.IsFaulted` будет равно true.

#### Обработка нескольких исключений. WhenAll
Если мы ожидаем выполнения сразу нескольких задач, например, с помощью **_Task.WhenAll_**, 
то мы можем получить сразу несколько исключений одномоментно для каждой выполняемой задачи. 
В этом случае мы можем получить все исключения из свойства **_Exception.InnerExceptions_**:
```csharp
static async Task DoMultipleAsync()
{
    Task allTasks = null;
 
    try
    {
        Task t1 = Task.Run(()=>Factorial(-3));
        Task t2 = Task.Run(() => Factorial(-5));
        Task t3 = Task.Run(() => Factorial(-10));
 
        allTasks = Task.WhenAll(t1, t2, t3);
        await allTasks;
    }
    catch (Exception ex)
    {
        Console.WriteLine("Исключение: " + ex.Message);
        Console.WriteLine("IsFaulted: " + allTasks.IsFaulted);
        foreach (var inx in allTasks.Exception.InnerExceptions)
        {
            Console.WriteLine("Внутреннее исключение: " + inx.Message);
        }
    }
}
```
Здесь в три вызова метода факториала передаются заведомо некорректные числа: `-3`, `-5`, `-10`. 
Таким образом, при всех трх вызовах будет сгенерирована ошибка.

Хотя блок **catch** через переменную `Exception ex` будет получать одно перехваченное исключение, но с помощью коллекции 
**_Exception.InnerExceptions_** мы сможем получить информацию обо всех возникших исключениях.

В итоге при выполнении этого метода мы получим следующий консольный вывод:
```
Исключение: -3 : число не должно быть меньше 1
IsFaulted: True
Внутреннее исключение: -3: число не должно быть меньше 1
Внутреннее исключение: -5: число не должно быть меньше 1
Внутреннее исключение: -10: число не должно быть меньше 1
```

#### await в блоках catch и finally
Начиная с версии C# 6.0 в язык была добавлена возможность вызова асинхронного кода в блоках **catch** и **finally**. 
Так, возьмем предыдущий пример с подсчетом факториала:
```csharp
static async void FactorialAsync(int n)
{
    try
    {
        await Task.Run(() => Factorial(n)); ;
    }
    catch (Exception ex)
    {
        await Task.Run(()=>Console.WriteLine(ex.Message));
    }
    finally
    {
        await Task.Run(() => Console.WriteLine("await в блоке finally"));
    }
}
```

### Отмена асинхронных операций
Для отмены асинхронных операций используются классы **CancellationToken** и **CancellationTokenSource**.

**CancellationToken** содержит информацию о том, надо ли отменять асинхронную задачу. 
Асинхронная задача, в которую передается объект **CancellationToken**, периодически проверяет состояние этого объекта. 
Если его свойство **_IsCancellationRequested_** равно **true**, то задача должна остановить все свои операции.

Для создания объекта **CancellationToken** применяется объект **CancellationTokenSource**. 
Кроме того, при вызове у **CancellationTokenSource** метода _Cancel()_ у объекта **CancellationToken** свойство 
**_IsCancellationRequested**_ будет установлено в **true**.
```csharp
using System;
using System.Threading;
using System.Threading.Tasks;
 
CancellationTokenSource cts = new CancellationTokenSource();
CancellationToken token = cts.Token;
FactorialAsync(6, token);
Thread.Sleep(3000);
cts.Cancel();
Console.Read();

static void Factorial(int n, CancellationToken token)
{
    int result = 1;
    for (int i = 1; i <= n; i++)
    {
        if (token.IsCancellationRequested)
        {
            Console.WriteLine(
                "Операция прервана токеном");
            return;
        }
        result *= i;
        Console.WriteLine(
            $"Факториал числа {i} равен {result}");
        Thread.Sleep(1000);
    }
}
// определение асинхронного метода
static async void FactorialAsync(int n, CancellationToken token)
{
    if(token.IsCancellationRequested)
        return;
    await Task.Run(()=>Factorial(n, token));
}
```
Для создания токена определяется объект **CancellationTokenSource**. Метод **_FactorialAsync_** в качестве параметра принимает токен, 
и если где-то во внешнем коде произойдет отмена операции через вызов **_cts.Cancel_**, 
то в методе **_Factorial_** свойство **_token.IsCancellationRequested_** будет равно **true**, 
и соответственно при очередной итерации цикла в методе **Factorial** произойдет выход из метода. 
И асинхронная операция завершится. И мы получим следующий консольный вывод:
```
Факториал числа 1 равен 1
Факториал числа 2 равен 2
Факториал числа 3 равен 6
Операция была отменена.
```