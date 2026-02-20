## Работа с дисками

___

Работу с файловой системой начнем с самого верхнего уровня - дисков. 
Для представления диска в пространстве имен `System.IO` имеется класс **DriveInfo**.

Этот класс имеет статический метод **_GetDrives_**, который возвращает имена всех логических дисков компьютера. 
Также он предоставляет ряд полезных свойств:
* **_AvailableFreeSpace_**: указывает на объем доступного свободного места на диске в байтах
* **_DriveFormat_**: получает имя файловой системы
* **_DriveType_**: представляет тип диска
* **_IsReady_**: готов ли диск (например, DVD-диск может быть не вставлен в дисковод)
* **_Name_**: получает имя диска
* **_TotalFreeSpace_**: получает общий объем свободного места на диске в байтах
* **_TotalSize_**: общий размер диска в байтах
* **_VolumeLabel_**: получает или устанавливает метку тома

[Получим имена и свойства всех дисков на компьютере](https://github.com/logitac/LabsOnCs/tree/master/labs/Lab9/drive/Drives.cs):
```csharp
using System.IO;

class Drives
{
    static void Main()
    {
        DriveInfo[] drives = DriveInfo.GetDrives();
        foreach (DriveInfo drive in drives)
        {
            Console.WriteLine($"Название: {drive.Name}");
            Console.WriteLine($"Тип: {drive.DriveType}");
            if (drive.IsReady)
            {
                Console.WriteLine($"Объём диска: {drive.TotalSize / 1024 / 1024 / 1024}");
                Console.WriteLine($"Свободное пространство: {drive.AvailableFreeSpace / 1024 / 1024 / 1024}");
            }

            Console.ReadKey();
        }
    }
}
```

Вывод:
```
Название: C:\
Тип: Fixed
Объём диска: 930
Свободное пространство: 349
```