using System.Collections.Generic;
using System.Threading.Tasks;
using ALevelSample.Dtos.Responses;

namespace ALevelSample.Services.Abstractions;

    public interface IResourceService
    {
        Task<List<ResourceDto>> GetResources();
        Task<ResourceDto> GetResourceById(int id);
    }