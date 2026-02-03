#if false
class Lab3_5
{
    static void Main()
    {
        int[] arr1 = { 100, 200, 300 };
        int[] arr2 = { 100, 200, 300, 400, 500, 600, 700, 800 };

        int sum = 0;

        for (int i = 0; i < arr1.Length; i++)
        {
            sum += arr1[i];
        }
        
        for (int i = 0; i < arr2.Length; i++)
        {
            sum += arr2[i];
        }
        
        Console.WriteLine(sum);
    }
}
#endif
//Ссылка на задачку: https://www.codewars.com/kata/5a2be17aee1aaefe2a000151/train/csharp