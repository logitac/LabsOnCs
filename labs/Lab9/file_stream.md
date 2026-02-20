## FileStream. Чтение и запись файла

___

Класс **FileStream** представляет возможности по считыванию из файла и записи в файл. 
Он позволяет работать как с текстовыми файлами, так и с бинарными.

### Создание FileStream
Для создания объекта **FileStream** можно использовать как конструкторы этого класса, так и статические методы класса **File**. 
Конструктор **FileStream** имеет множество перегруженных версий, из которых отмечу лишь одну, самую простую и используемую:
```csharp
FileStream(string filename, FileMode mode)
```
Здесь в конструктор передается два параметра: путь к файлу и перечисление (**enum**) **_FileMode_**. 
Данное перечисление указывает на режим доступа к файлу и может принимать следующие значения:

* **_Append_**: если файл существует, то текст добавляется в конец файл. Если файла нет, то он создается. Файл открывается только для записи.
* **_Create_**: создается новый файл. Если такой файл уже существует, то он перезаписывается.
* **_CreateNew_**: создается новый файл. Если такой файл уже существует, то он приложение выбрасывает ошибку.
* **_Open_**: открывает файл. Если файл не существует, выбрасывается исключение.
* **_OpenOrCreate_**: если файл существует, он открывается, если нет - создается новый.
* **_Truncate_**: если файл существует, то он перезаписывается. Файл открывается только для записи.

Другой способ создания объекта FileStream представляют статические методы класса File:
```csharp
FileStream File.Open(string file, FileMode mode);
FileStream File.OpenRead(string file);
FileStream File.OpenWrite(string file);
```

Первый метод открывает файл с учетом объекта **_FileMode_** и возвращает файловой поток **FileStream**. 
У этого метода также есть несколько перегруженных версий. Второй метод открывает поток для чтения, а третий открывает поток для записи.

### Свойства и методы FileStream
Рассмотрим наиболее важные его свойства и методы класса **FileStream**:

* Свойство **_Length_**: возвращает длину потока в байтах
* Свойство **_Position_**: возвращает текущую позицию в потоке
* **_void CopyTo(Stream destination)_**: копирует данные из текущего потока в поток destination
* **_Task CopyToAsync(Stream destination)_**: асинхронная версия метода CopyToAsync
* **_int Read(byte[] array, int offset, int count)_**: считывает данные из файла в массив байтов и возвращает количество успешно считанных байтов. 
Принимает три параметра:
  * **_array_** - массив байтов, куда будут помещены считываемые из файла данные
  * **_offset_** представляет смещение в байтах в массиве array, в который считанные байты будут помещены
  * **_count_** - максимальное число байтов, предназначенных для чтения. Если в файле находится меньшее количество байтов, то все они будут считаны.
* `Task<int> ReadAsync(byte[] array, int offset, int count)`: асинхронная версия метода Read
* `long Seek(long offset, SeekOrigin origin)`: устанавливает позицию в потоке со смещением на количество байт, указанных в параметре offset.
* `void Write(byte[] array, int offset, int count)`: записывает в файл данные из массива байтов. Принимает три параметра:
    * **_array_** - массив байтов, откуда данные будут записываться в файл
    * **_offset_** - смещение в байтах в массиве array, откуда начинается запись байтов в поток
    * **_count_** - максимальное число байтов, предназначенных для записи
* `ValueTask WriteAsync(byte[] array, int offset, int count)`: асинхронная версия метода Write

### Чтение и запись файлов
FileStream представляет доступ к файлам на уровне байтов, поэтому, например, если вам надо считать или записать одну, или несколько строк 
в текстовый файл, то массив байтов надо преобразовать в строки, используя специальные методы. 
Поэтому для работы с текстовыми файлами применяются другие классы.

В то же время при работе с различными бинарными файлами, имеющими определенную структуру, 
**FileStream** может быть очень даже полезен для извлечения определенных порций информации и ее обработки.

Посмотрим на примере [считывания-записи в текстовый файл](https://github.com/logitac/LabsOnCs/tree/master/labs/Lab9/fileStream/ReadAndWriteFile.cs):
```csharp
using System.IO;
using System.Text;

class ReadAndWriteFile
{
    static void Main()
    {
        string path = @"C:/SomeDir";
        DirectoryInfo dir = new DirectoryInfo(path);
        if(!dir.Exists)
            dir.Create();

        Console.Write("Введите строку для записи в файл: ");
        string text = Console.ReadLine();

        using (FileStream fstream = new FileStream($"{path}/note.txt", FileMode.OpenOrCreate))
        {
            byte[] buffer = System.Text.Encoding.Default.GetBytes(text);
            fstream.Write(buffer, 0, buffer.Length);
            Console.WriteLine("Текст записан в файл");
        }

        using (FileStream fstream = File.OpenRead($"{path}/note.txt"))
        {
            byte[] buffer = new byte[fstream.Length];
            fstream.Read(buffer, 0, buffer.Length);
            string textFromFile = System.Text.Encoding.Default.GetString(buffer);
            Console.WriteLine($"Текст из файла: {textFromFile}");
        }
    }
}
```

И при чтении, и при записи используется оператор **using**. Не надо путать данный оператор с директивой **using**, 
которая подключает пространства имен в начале файла кода. Оператор **using** позволяет создавать объект в блоке кода, 
по завершению которого вызывается метод **_Dispose_** у этого объекта, и, таким образом, объект уничтожается. 
В данном случае в качестве такого объекта служит переменная **_fstream_**.

И при записи, и при чтении применяется объект кодировки `Encoding.Default` из пространства имен `System.Text`. 
В данном случае мы используем два его метода: **_GetBytes_** для получения массива байтов из строки и 
**_GetString_** для получения строки из массива байтов.

В итоге введенная нами строка записывается в файл `note.txt`. По сути это бинарный файл (не текстовый), 
хотя если мы в него запишем только строку, то сможем посмотреть в удобочитаемом виде этот файл, открыв его в текстовом редакторе. 
Однако если мы в него запишем случайные байты, например:
```csharp
fstream.WriteByte(13);
fstream.WriteByte(103);
```

То у нас могут возникнуть проблемы с его пониманием. 
Поэтому для работы непосредственно с текстовыми файлами предназначены отдельные классы - **StreamReader** и **StreamWriter**.

В реальных приложениях рекомендуется использовать асинхронные версии методов **FileStream**, 
поскольку операции с файлами могут занимать продолжительное время и являются узким местом в работе программы. 
Например, изменим [выше приведенную программу](https://github.com/logitac/LabsOnCs/tree/master/labs/Lab9/fileStream/ReadAndWriteFileAsync.cs), применив асинхронные методы:
```csharp
using System.IO;
using System.Threading.Tasks;
using System.Text;

class ReadAndWriteFileAsync
{
    static async Task Main()
    {
        string path = @"C:/SomeDir";
        DirectoryInfo dir = new DirectoryInfo(path);
        if(!dir.Exists)
            dir.Create();
        Console.Write("Введите строку для записи в файл: ");
        string text = Console.ReadLine();

        using (FileStream fs = new FileStream($"{path}/note.txt", FileMode.OpenOrCreate))
        {
            byte[] bytes = System.Text.Encoding.Default.GetBytes(text);
            await fs.WriteAsync(bytes, 0, bytes.Length);
            Console.WriteLine("Текст записан в файл");
        }

        using (FileStream fs = File.OpenRead($"{path}/note.txt"))
        {
            byte[] bytes = new byte[fs.Length];
            await fs.ReadAsync(bytes, 0, bytes.Length);
            string textFromFile = System.Text.Encoding.Default.GetString(bytes);
            Console.WriteLine($"Текст из файла: {textFromFile}");
        }
    }
}
```

### Произвольный доступ к файлам
Нередко бинарные файлы представляют определенную структуру. И, зная эту структуру, мы можем взять из файла нужную порцию 
информации или наоборот записать в определенном месте файла определенный набор байтов. Например, в wav-файлах непосредственно 
звуковые данные начинаются с 44 байта, а до 44 байта идут различные метаданные - количество каналов аудио, частота дискретизации и т.д.

С помощью метода **_Seek_** мы можем управлять положением курсора потока, начиная с которого производится считывание или запись в файл. 
Этот метод принимает два параметра: **_offset_** (смещение) и позиция в файле. Позиция в файле описывается тремя значениями:

* `SeekOrigin.Begin`: начало файла
* `SeekOrigin.End`: конец файла
* `SeekOrigin.Current`: текущая позиция в файле

Курсор потока, с которого начинается чтение или запись, смещается вперед на значение **_offset_** относительно позиции, 
указанной в качестве второго параметра. Смещение может быть отрицательным, тогда курсор сдвигается назад, если положительное - то вперед.

Рассмотрим на [примере](https://github.com/logitac/LabsOnCs/tree/master/labs/Lab9/fileStream/UsingSeek.cs):
```csharp
using System;
using System.IO;
using System.Text;


class UsingSeek
{
    static void Main(string[] args)
    {
        string text = "hello world";

        using (FileStream fstream = new FileStream($"C:/SomeDir/note.dat", FileMode.OpenOrCreate))
        {
            byte[] input = System.Text.Encoding.Default.GetBytes(text);
            fstream.Write(input, 0, input.Length);
            Console.WriteLine("Текст записан в файл");
            
            fstream.Seek(-5, SeekOrigin.End);

            byte[] output = new byte[4];
            fstream.Read(output, 0, output.Length);
            string textFromFile = Encoding.UTF8.GetString(output);
            Console.WriteLine($"Текст из файла: {textFromFile}"); // worl

            string replaceText = "house";
            fstream.Seek(-5, SeekOrigin.End);
            input = Encoding.Default.GetBytes(replaceText);
            fstream.Write(input, 0, input.Length);
            
            fstream.Seek(0, SeekOrigin.Begin);
            output = new byte[fstream.Length];
            fstream.Read(output, 0, output.Length);
            textFromFile = Encoding.Default.GetString(output);
            Console.WriteLine($"Текст из файла: {textFromFile}");
        }
    }
}
```
Консольный вывод:
```
Текст записан в файл
Текст из файла: worl
Текст из файла: hello house
```

### Чтение и запись текстовых файлов. StreamReader и StreamWriter
Класс **FileStream** не очень удобно применять для работы с текстовыми файлами. 
Для этого в пространстве `System.IO` определены специальные классы: **StreamReader** и **StreamWriter**.

#### Запись в файл и StreamWriter
Для записи в текстовый файл используется класс **StreamWriter**. Некоторые из его конструкторов, 
которые могут применяться для создания объекта **StreamWriter**:

* `StreamWriter(string path)`: через параметр path передается путь к файлу, который будет связан с потоком
* `StreamWriter(string path, bool append)`: параметр append указывает, надо ли добавлять в конец файла данные или же перезаписывать файл. 
Если равно true, то новые данные добавляются в конец файла. Если равно false, то файл перезаписывается заново
* `StreamWriter(string path, bool append, System.Text.Encoding encoding)`: параметр encoding указывает на кодировку, которая будет применяться при записи

Свою функциональность **StreamWriter** реализует через следующие методы:

* `int Close()`: закрывает записываемый файл и освобождает все ресурсы
* `void Flush()`: записывает в файл оставшиеся в буфере данные и очищает буфер.
* `Task FlushAsync()`: асинхронная версия метода **_Flush_**
* `void Write(string value)`: записывает в файл данные простейших типов, как **int**, **double**, **char**, **string** и т.д. 
Соответственно имеет ряд перегруженных версий для записи данных элементарных типов, например, 
`Write(char value)`, `Write(int value)`, `Write(double value)` и т.д.
* `Task WriteAsync(string value)`: асинхронная версия метода **_Write_**
* `void WriteLine(string value)`: также записывает данные, только после записи добавляет в файл символ окончания строки (`\n`)
* `Task WriteLineAsync(string value)`: асинхронная версия метода **_WriteLine_**

Рассмотрим запись в файл на [примере](https://github.com/logitac/LabsOnCs/tree/master/labs/Lab9/fileStream/UsingStreamWriter.cs):
```csharp
using System.IO;
using System.Text;

class UsingStreamWriter
{
    static void Main()
    {
        string writePath = @"C:/SomeDir/hta.txt";
        string text = "Hello World!\nПока мир...";
        try
        {
            using (StreamWriter sw = new StreamWriter(writePath, false, Encoding.Default))
            {
                sw.WriteLine(text);
            }

            using (StreamWriter sw = new StreamWriter(writePath, true, Encoding.Default))
            {
                sw.WriteLine("Дозапись");
                sw.Write(4.5);
            }

            Console.WriteLine("Запись выполнена");
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
```
В данном случае два раза создаем объект **StreamWriter**. В первом случае если файл существует, то он будет перезаписан. 
Если не существует, он будет создан. И в нее будет записан текст из переменной text. Во втором случае файл открывается для дозаписи, 
и будут записаны атомарные данные - строка и число. В обоих случаях будет использоваться кодировка по умолчанию.

По завершении программы в папке `C:/SomeDir` мы сможем найти файл `hta.txt`, который будет иметь следующие строки:
```
Привет мир!
Пока мир...
Дозапись
4,5
```
Поскольку операции с файлами могут занимать продолжительное время, то в общем случае рекомендуется использовать асинхронную запись. 
[Используем асинхронные версии методов](https://github.com/logitac/LabsOnCs/tree/master/labs/Lab9/fileStream/UsingStreamWriterAsync.cs):
```csharp
using System.IO;
using System.Text;

class UsingStreamWriterAsync
{
    static async Task Main()
    {
        string writePath = @"C:/SomeDir/hta.txt";
        string text = "Hello World!\nПока мир...";
        try
        {
            using (StreamWriter sw = new StreamWriter(writePath, false, Encoding.Default))
            {
                await sw.WriteLineAsync(text);
            }

            using (StreamWriter sw = new StreamWriter(writePath, true, Encoding.Default))
            {
                await sw.WriteLineAsync("Дозапись");
                await sw.WriteAsync("4,5");
            }

            Console.WriteLine("Запись выполнена");
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
```
Обратите внимание, что асинхронные версии есть не для всех перегрузок метода **_Write_**.

#### Чтение из файла и StreamReader
Класс **StreamReader** позволяет нам легко считывать весь текст или отдельные строки из текстового файла.

Некоторые из конструкторов класса **StreamReader**:

* `StreamReader(string path)`: через параметр path передается путь к считываемому файлу
* `StreamReader(string path, System.Text.Encoding encoding)`: параметр encoding задает кодировку для чтения файла

Среди методов **StreamReader** можно выделить следующие:

* `void Close()`: закрывает считываемый файл и освобождает все ресурсы
* `int Peek()`: возвращает следующий доступный символ, если символов больше нет, то возвращает -1
* `int Read()`: считывает и возвращает следующий символ в численном представлении. 
Имеет перегруженную версию: `Read(char[] array, int index, int count)`, где array - массив, куда считываются символы, 
index - индекс в массиве array, начиная с которого записываются считываемые символы, и count - максимальное количество считываемых символов
* `Task<int> ReadAsync()`: асинхронная версия метода Read
* `string ReadLine()`: считывает одну строку в файле
* `string ReadLineAsync()`: асинхронная версия метода **_ReadLine_**
* `string ReadToEnd()`: считывает весь текст из файла
* `string ReadToEndAsync()`: асинхронная версия метода **_ReadToEnd_**

Сначала считаем текст полностью из [ранее записанного файла](https://github.com/logitac/LabsOnCs/tree/master/labs/Lab9/fileStream/UsingStreamReader.cs):
```csharp
using System.IO;
using System.Text;

class UsingStreamReader
{
    static async Task Main()
    {
        string path = @"C:/SomeDir/hta.txt";

        try
        {
            using (StreamReader sr = new StreamReader(path))
            {
                Console.WriteLine(sr.ReadToEnd());
            }

            using (StreamReader sr = new StreamReader(path))
            {
                Console.WriteLine(await sr.ReadToEndAsync());
            }
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
```
[Считаем текст из файла построчно](https://github.com/logitac/LabsOnCs/tree/master/labs/Lab9/fileStream/UsingStreamReaderLine.cs):
```csharp
using System.IO;
using System.Text;


class UsingStreamReaderLine
{
    static async Task Main()
    {
        string path= @"C:\SomeDir\hta.txt";
        using (StreamReader sr = new StreamReader(path, Encoding.Default))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
        
        // Асинхронное чтение
        using (StreamReader sr = new StreamReader(path, Encoding.Default))
        {
            string line;
            while ((line = await sr.ReadLineAsync()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}
```
В данном случае считываем построчно через цикл **while**: `while ((line = sr.ReadLine()) != null)` - сначала присваиваем переменной line результат 
функции `sr.ReadLine()`, а затем проверяем, не равна ли она **null**. Когда объект `sr` дойдет до конца файла и больше строк не останется, 
то метод `sr.ReadLine()` будет возвращать **null**.


