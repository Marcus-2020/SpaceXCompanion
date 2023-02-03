using System.Net.Mime;
using System.Text;
using Newtonsoft.Json;

namespace SpaceXCompanion.API.Helpers;

public class ExternalRequestHelper : IExternalRequestHelper
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ExternalRequestHelper(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    public async Task<(HttpResponseMessage Response, string Content)> ExecuteRequest(
        HttpMethod method, string clientName, string resource)
    {
        var httpClient = _httpClientFactory.CreateClient(clientName);
        
        var request = new HttpRequestMessage
        {
            Method = method,
            RequestUri = new Uri((httpClient.BaseAddress?.AbsoluteUri ?? "") + resource)
        };
        
        var response = await httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();

        return (response, content);
    }
    
    public async Task<(HttpResponseMessage Response, string Content)> ExecuteRequest<T>(
        HttpMethod method, string clientName, string resource, T data)
    {
        var httpClient = _httpClientFactory.CreateClient(clientName);
        
        var request = new HttpRequestMessage
        {
            Method = method,
            RequestUri = new Uri((httpClient.BaseAddress?.AbsoluteUri ?? "") + resource),
            Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, 
                MediaTypeNames.Application.Json),
        };
        
        var response = await httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();

        return (response, content);
    }
    
    public async Task<(HttpResponseMessage Response, T? Data)> ExecuteRequest<T>(HttpMethod method, string clientName, string resource)
    {
        var httpClient = _httpClientFactory.CreateClient(clientName);
        
        var request = new HttpRequestMessage
        {
            Method = method,
            RequestUri = new Uri((httpClient.BaseAddress?.AbsoluteUri ?? "") + resource)
        };
        
        var response = await httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();

        var data = JsonConvert.DeserializeObject<T>(content);
        
        return (response, data);
    }
}