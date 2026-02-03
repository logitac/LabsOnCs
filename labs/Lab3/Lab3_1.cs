#if false
public class Lab3_1
{
    public static string Smash(string[] words)
    {
        string[] words = new string[] { "hello", "amazing", "world" };
        string str = "";
    
        foreach(string s in words)
        {
            str += str.Length == 0 ? s : " " + s;    
        }
    
        return str;
    }
}
#endif

// Ссылка на задачку: https://www.codewars.com/kata/53dc23c68a0c93699800041d/train/csharp