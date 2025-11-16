using GhazaSystem.Common.Data;
using GhazaSystem.UI.Interfaces;
using GhazaSystem.UI.Shared;
using GhazaSystem.Common.DTOs;


namespace GhazaSystem.UI.Services;

public class LoginServices(IHttpClientFactory httpClient) : ILoginServices
{
    private readonly HttpClient http = httpClient.CreateClient("api");
    public async Task<Response<Login>> AddAsync(Login model)
    {
        var response = await http.PostAsJsonAsync(LoginUrlApi.add, model);
        return await response.ToResponse<Login>();
    }

    public async Task<Response<object>> DeleteAsync(Guid id)
    {
        var response = await http.DeleteAsync(LoginUrlApi.delete(id));
        return await response.ToResponse<object>();
    }

    public async Task<Response<List<Login>>> GetAllAsync()
    {
        var response = await http.GetAsync(LoginUrlApi.all);
        return await response.ToResponse<List<Login>>();
    }

    public async Task<Response<Login>> GetByIdAsync(Guid id)
    {
        var response = await http.GetAsync(LoginUrlApi.getId(id));
        return await response.ToResponse<Login>();
    }

    public async Task<Response<Login>> UpdateAsync(Login model)
    {
        var response = await http.PostAsJsonAsync(LoginUrlApi.update, model);
        return await response.ToResponse<Login>();
    }
}
