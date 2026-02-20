using System.IO;

#if false
class Drives
{
    static void Main()
    {
        var drives = DriveInfo.GetDrives();
        
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
#endif