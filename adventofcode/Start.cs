static class Program
{
    static void Main()
    {
        Day4.Part2();
    }
    
    public static string GetInputPath(string fileName) => System.IO.Path.Combine(@"../../../Inputs", fileName);
}