## Работа с каталогами

___

Для работы с каталогами в пространстве имен `System.IO` предназначены сразу два класса: **Directory** и **DirectoryInfo**.

### Класс Directory

Класс **Directory** предоставляет ряд статических методов для управления каталогами. Некоторые из этих методов:
* **_CreateDirectory(path)_**: создает каталог по указанному пути path
* **_Delete(path)_**: удаляет каталог по указанному пути path
* **_Exists(path)_**: определяет, существует ли каталог по указанному пути path. Если существует, возвращается true, если не существует, то false
* **_GetDirectories(path)_**: получает список каталогов в каталоге path
* **_GetFiles(path)_**: получает список файлов в каталоге path
* **_Move(sourceDirName, destDirName)_**: перемещает каталог
* **_GetParent(path)_**: получение родительского каталога

### Класс DirectoryInfo

Данный класс предоставляет функциональность для создания, удаления, перемещения и других операций с каталогами. 
Во многом он похож на **Directory**. Некоторые из его свойств и методов:

* **_Create()_**: создает каталог
* **_CreateSubdirectory(path)_**: создает подкаталог по указанному пути path
* **_Delete()_**: удаляет каталог
* Свойство **_Exists_**: определяет, существует ли каталог
* **_GetDirectories()_**: получает список каталогов
* **_GetFiles()_**: получает список файлов
* **_MoveTo(destDirName)_**: перемещает каталог
* Свойство **_Parent_**: получение родительского каталога
* Свойство **_Root_**: получение корневого каталога

Посмотрим на примерах применение этих классов
#### [Получение списка файлов и подкаталогов](https://github.com/logitac/LabsOnCs/tree/master/labs/Lab9/directory/GetSubDirectoriesAndListFiles.cs)
```csharp
string dirName = "C:/";
 
if (Directory.Exists(dirName))
{
    Console.WriteLine("Подкаталоги:");
    string[] dirs = Directory.GetDirectories(dirName);
    foreach (string s in dirs)
    {
        Console.WriteLine(s);
    }
    Console.WriteLine();
    Console.WriteLine("Файлы:");
    string[] files = Directory.GetFiles(dirName);
    foreach (string s in files)
    {
        Console.WriteLine(s);
    }
}
```

#### [Создание каталога](https://github.com/logitac/LabsOnCs/tree/master/labs/Lab9/directory/CreateDirectory.cs)
```cs
string path = @"C:\SomeDir";
string subpath = @"program\avalon";
DirectoryInfo dirInfo = new DirectoryInfo(path);
if (!dirInfo.Exists)
{
    dirInfo.Create();
}
dirInfo.CreateSubdirectory(subpath);
```
Вначале проверяем, а нет ли такой директории, так как если она существует, то ее создать будет нельзя, и приложение выбросит ошибку. 
В итоге у нас получится следующий путь: `C:\SomeDir\program\avalon`

#### [Получение информации о каталоге](https://github.com/logitac/LabsOnCs/tree/master/labs/Lab9/directory/GetDirectoryInfo.cs)
```csharp
string dirName = "C:\\Program Files";
 
DirectoryInfo dirInfo = new DirectoryInfo(dirName);
 
Console.WriteLine($"Название каталога: {dirInfo.Name}");
Console.WriteLine($"Полное название каталога: {dirInfo.FullName}");
Console.WriteLine($"Время создания каталога: {dirInfo.CreationTime}");
Console.WriteLine($"Корневой каталог: {dirInfo.Root}");
```

#### [Удаление каталога](https://github.com/logitac/LabsOnCs/tree/master/labs/Lab9/directory/DeleteDirectory.cs)
Если мы просто применим метод **_Delete_** к непустой папке, в которой есть какие-нибудь файлы или подкаталоги, то приложение нам выбросит ошибку. 
Поэтому нам надо передать в метод **_Delete_** дополнительный параметр булевого типа, который укажет, что папку надо удалять со всем содержимым:
```csharp
string dirName = @"C:\SomeDir";
 
try
{
    DirectoryInfo dirInfo = new DirectoryInfo(dirName);
    dirInfo.Delete(true);
    Console.WriteLine("Каталог удален");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```
Или так:
```csharp
string dirName = @"C:\SomeDir";
 
Directory.Delete(dirName, true);
```

#### [Перемещение каталога](https://github.com/logitac/LabsOnCs/tree/master/labs/Lab9/directory/MoveDirectory.cs)
```csharp
string oldPath = @"C:\SomeFolder";
string newPath = @"C:\SomeDir";
DirectoryInfo dirInfo = new DirectoryInfo(oldPath);
if (dirInfo.Exists && Directory.Exists(newPath) == false)
{
    dirInfo.MoveTo(newPath);
}
```
При перемещении надо учитывать, что новый каталог, в который мы хотим перемесить все содержимое старого каталога, не должен существовать.