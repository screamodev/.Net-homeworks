using Module2HW5.Config.Comparers;

namespace Module2HW5.Repositories;

public class FileRepository
{
    const int MAX_FILES_AMOUNT = 3;

    private DirectoryInfo CreateDirectory(string directoryName)
    {
        DirectoryInfo directory = new DirectoryInfo(@$"./{directoryName}");
        try
        {
            if (directory.Exists)
            {
                Console.WriteLine("That path exists already.");
                return directory;
            }

            directory.Create();
            Console.WriteLine("The directory was created successfully.");
        }
        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }

        return directory;
    }
    
    public void WriteFile(string directoryName, string data)
    {
        DirectoryInfo directory = CreateDirectory(directoryName);

        var files = directory.GetFiles();
        
        if (directory.GetFiles().Length == MAX_FILES_AMOUNT)
        {
            Array.Sort(files, new SortFileByDateComparer());
            
            File.Delete(@$"./{directoryName}/{files.First().Name}");
        }
        
        FileStream file = new FileStream(@$"./{directoryName}/{DateTime.Now}.txt", FileMode.OpenOrCreate,
            FileAccess.Write, FileShare.ReadWrite);
        
        BinaryWriter bw = new BinaryWriter(file);
        
        bw.Write(data);
        bw.Close();
        
        Console.WriteLine("Logs has been saved!");
    }
}