using Homeworks.Module2HW1.Repositories;

namespace Homeworks.Module2HW1;

public class FileService
{
    private readonly FileRepository _repository;
    
    public FileService(FileRepository repository)
    {
        _repository = repository;
    }
    
    public void WriteFile(string directoryName, string data)
    {
        _repository.WriteFile(directoryName, data);
    }
}