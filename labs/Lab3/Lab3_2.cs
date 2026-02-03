#if false
class Lab3_2
{
    static void Main(string[] args)
    {
        int[] currentArray = new int[5] {1,2,3,4,5};
        
        int[] newArray = new int[currentArray.Length];
        for(int i = 0; i < currentArray.Length; i++)
        {
            newArray[i] = currentArray[i]*(-1);
        }

        foreach (int i in newArray)
        {
            Console.Write(i + " ");
        }
    }
}
#endif

// Ссылка на задачку: https://www.codewars.com/kata/5899dc03bc95b1bf1b0000ad/train/csharp