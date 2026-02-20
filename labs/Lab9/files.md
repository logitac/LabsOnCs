## Работа с файлами

___

Подобно паре **Directory**/**DirectoryInfo** для работы с файлами предназначена пара классов **File** и **FileInfo**. 
С их помощью мы можем создавать, удалять, перемещать файлы, получать их свойства и многое другое.

Некоторые полезные методы и свойства класса **FileInfo**:
* **_CopyTo(path)_**: копирует файл в новое место по указанному пути path
* **Create()**: создает файл
* **Delete()**: удаляет файл
* **MoveTo(destFileName)**: перемещает файл в новое место
* Свойство **_Directory_**: получает родительский каталог в виде объекта _DirectoryInfo_
* Свойство **DirectoryName**: получает полный путь к родительскому каталогу
* Свойство **_Exists_**: указывает, существует ли файл
* Свойство **_Length_**: получает размер файла
* Свойство **_Extension_**: получает расширение файла
* Свойство **_Name_**: получает имя файла
* Свойство **_FullName_**: получает полное имя файла

Класс File реализует похожую функциональность с помощью статических методов:
* **_Copy()_**: копирует файл в новое место
* **_Create()_**: создает файл
* **_Delete()_**: удаляет файл
* **_Move_**: перемещает файл в новое место
* **_Exists(file)_**: определяет, существует ли файл

### [Получение информации о файле](https://github.com/logitac/LabsOnCs/tree/master/labs/Lab9/file/GetFileInfo.cs)
```csharp
string path = @"C:\apache\hta.txt";
FileInfo fileInf = new FileInfo(path);
if (fileInf.Exists)
{
    Console.WriteLine("Имя файла: {0}", fileInf.Name);
    Console.WriteLine("Время создания: {0}", fileInf.CreationTime);
    Console.WriteLine("Размер: {0}", fileInf.Length);
}
```
### [Удаление файла](https://github.com/logitac/LabsOnCs/tree/master/labs/Lab9/file/DeleteFile.cs)
```csharp
string path = @"C:\apache\hta.txt";
FileInfo fileInf = new FileInfo(path);
if (fileInf.Exists)
{
   fileInf.Delete();
   // альтернатива с помощью класса File
   // File.Delete(path);
}
```
### [Перемещение файла](https://github.com/logitac/LabsOnCs/tree/master/labs/Lab9/file/MoveFile.cs)
```csharp
string path = @"C:\apache\hta.txt";
string newPath = @"C:\SomeDir\hta.txt";
FileInfo fileInf = new FileInfo(path);
if (fileInf.Exists)
{
   fileInf.MoveTo(newPath);       
   // альтернатива с помощью класса File
   // File.Move(path, newPath);
}
```
### [Копирование файла](https://github.com/logitac/LabsOnCs/tree/master/labs/Lab9/file/CopyFile.cs)
```csharp
string path = @"C:\apache\hta.txt";
string newPath = @"C:\SomeDir\hta.txt";
FileInfo fileInf = new FileInfo(path);
if (fileInf.Exists)
{
   fileInf.CopyTo(newPath, true);      
   // альтернатива с помощью класса File
   // File.Copy(path, newPath, true);
}
```
Метод **_CopyTo_** класса **FileInfo** принимает два параметра: путь, по которому файл будет копироваться, и булевое значение, которое указывает, 
надо ли при копировании перезаписывать файл (если **true**, как в случае выше, файл при копировании перезаписывается). 
Если же в качестве последнего параметра передать значение **false**, то если такой файл уже существует, приложение выдаст ошибку.

Метод Copy класса **File** принимает три параметра: путь к исходному файлу, путь, по которому файл будет копироваться, и булевое значение, 
указывающее, будет ли файл перезаписываться.