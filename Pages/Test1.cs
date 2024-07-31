namespace SpecFlowProject1.Pages;

public class Test1
{
    public static void Main(string[] args)
    {
        string str = "Pallavi Gupta";
        string[] word = str.Split(" ");
        
        foreach (string w in word)
        {
         Console.Write(w.Reverse() + " ");    
        }
        {
            
        }

    }
}