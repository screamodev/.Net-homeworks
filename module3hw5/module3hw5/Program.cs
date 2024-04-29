public class Program
{
    private static async Task<string> ReadFile(string filename)
    {
        var file = await File.ReadAllLinesAsync(filename);
        return file[0];
    }
    
    private static async void MethodsExecutor()
    {
      var hello = await ReadFile("../../../hello.txt");
      var world = await ReadFile("../../../world.txt");

      Console.WriteLine(hello + world);
    }
    
    public static void Main()
    {
        MethodsExecutor();
    }
}