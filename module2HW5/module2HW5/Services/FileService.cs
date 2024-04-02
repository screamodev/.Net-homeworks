using Module2HW5.Repositories;

namespace Module2HW5.Services;

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