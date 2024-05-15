using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ALevelSample.Config;
using ALevelSample.Dtos;
using ALevelSample.Dtos.Responses;
using ALevelSample.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ALevelSample.Services;

public class ResourceService : IResourceService
{
    private readonly IInternalHttpClientService _httpClientService;
    private readonly ILogger<ResourceService> _logger;
    private readonly ApiOption _options;
    private readonly string _resourceApi = "api/unknown/";

    public ResourceService(IInternalHttpClientService httpClientService, IOptions<ApiOption> options, ILogger<ResourceService> logger)
    {
        _httpClientService = httpClientService;
        _options = options.Value;
        _logger = logger;
    }

    public async Task<List<ResourceDto>> GetResources()
    {
        var result = await _httpClientService.SendAsync<ListResponse<ResourceDto>, object>($"{_options.Host}{_resourceApi}", HttpMethod.Get);
        if (result?.Data == null)
        {
            _logger.LogInformation($"Resources are empty");
        }

        return result?.Data;
    }

    public async Task<ResourceDto> GetResourceById(int id)
    {
        var result = await _httpClientService.SendAsync<BaseResponse<ResourceDto>, object>($"{_options.Host}{_resourceApi}/{id}", HttpMethod.Get);

        if (result?.Data == null)
        {
            _logger.LogInformation($"User not found");
        }

        return result?.Data;
    }
}