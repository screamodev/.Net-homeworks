using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ALevelSample.Dtos.Responses;
using ALevelSample.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ALevelSample.Services;

public class InternalHttpClientService : IInternalHttpClientService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly ILogger<InternalHttpClientService> _logger;

    public InternalHttpClientService(IHttpClientFactory clientFactory, ILogger<InternalHttpClientService> logger)
    {
        _clientFactory = clientFactory;
        _logger = logger;
    }

    public async Task<TResponse> SendAsync<TResponse, TRequest>(string url, HttpMethod method, TRequest content = null)
        where TRequest : class
    {
        var client = _clientFactory.CreateClient();

        var httpMessage = new HttpRequestMessage();
        httpMessage.RequestUri = new Uri(url);
        httpMessage.Method = method;

        if (content != null)
        {
            httpMessage.Content =
                new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            Console.WriteLine(JsonConvert.SerializeObject(content));
        }

        var result = await client.SendAsync(httpMessage);

        if (result.StatusCode == HttpStatusCode.NoContent)
        {
                return (TResponse)(object)true;
        }

        if (result.StatusCode == HttpStatusCode.BadRequest)
        {
            var resultContent = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ErrorResponse>(resultContent);
            _logger.LogInformation($"Failed response: {JsonConvert.SerializeObject(response)}");
        }

        if (result.IsSuccessStatusCode)
        {
            var resultContent = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<TResponse>(resultContent);
            return response!;
        }

        return default(TResponse) !;
    }
}