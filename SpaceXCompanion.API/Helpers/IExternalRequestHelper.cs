namespace SpaceXCompanion.API.Helpers;

public interface IExternalRequestHelper
{
    Task<(HttpResponseMessage Response, string Content)> ExecuteRequest(HttpMethod method, string clientName, string resource);
    Task<(HttpResponseMessage Response, string Content)> ExecuteRequest<T>(HttpMethod method, string clientName, string resource, T data);
    Task<(HttpResponseMessage Response, T? Data)> ExecuteRequest<T>(HttpMethod method, string clientName, string resource);
}