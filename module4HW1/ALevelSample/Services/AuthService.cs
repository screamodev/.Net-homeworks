using System.Net.Http;
using System.Threading.Tasks;
using ALevelSample.Config;
using ALevelSample.Dtos.Requests;
using ALevelSample.Dtos.Responses;
using ALevelSample.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ALevelSample.Services;

public class AuthService : IAuthService
{
    private readonly IInternalHttpClientService _httpClientService;
    private readonly ILogger<ResourceService> _logger;
    private readonly ApiOption _options;
    private readonly string _registerApi = "api/register";
    private readonly string _loginApi = "api/login";

    public AuthService(IInternalHttpClientService httpClientService, IOptions<ApiOption> options, ILogger<ResourceService> logger)
    {
        _httpClientService = httpClientService;
        _options = options.Value;
        _logger = logger;
    }

    public async Task<AuthResponse> Register(string email, string password)
    {
        var result = await _httpClientService.SendAsync<AuthResponse, AuthRequest>(
            $"{_options.Host}{_registerApi}",
            HttpMethod.Post,
            new AuthRequest()
            {
                Email = email,
                Password = password
            });

        if (result == null)
        {
            _logger.LogInformation($"Registration has failed");
        }

        return result;
    }

    public async Task<AuthResponse> Login(string email, string password)
    {
        var result = await _httpClientService.SendAsync<AuthResponse, AuthRequest>(
            $"{_options.Host}{_loginApi}",
            HttpMethod.Post,
            new AuthRequest()
            {
                Email = email,
                Password = password
            });

        if (result == null)
        {
            _logger.LogInformation($"Login has failed");
        }

        return result;
    }
}