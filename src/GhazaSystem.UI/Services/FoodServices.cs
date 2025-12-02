
using GhazaSystem.Common.Data;
using GhazaSystem.Common.DTOs;
using GhazaSystem.UI.Interfaces;
using GhazaSystem.UI.Shared;
using System.Net.Http;

namespace GhazaSystem.UI.Services;

public class FoodServices(IHttpClientFactory httpClient) : IFoodServices
{
    private readonly HttpClient http = httpClient.CreateClient("api");
    public async Task<Response<Food>> AddAsync(Common.DTOs.FoodDTOs model)
    {
        var response = await http.PostAsJsonAsync(FoodUrlApi.add, model);
        return await response.ToResponse<Food>();
    }

    public async Task<Response<object>> DeleteAsync(Guid id)
    {
        var response = await http.DeleteAsync(FoodUrlApi.delete(id));
        return await response.ToResponse<object>();
    }

    public async Task<Response<List<Food>>> GetAllAsync()
    {
        var response = await http.GetAsync(FoodUrlApi.all);
        return await response.ToResponse<List<Food>>();
    }

    public async Task<Response<Food>> GetByIdAsync(Guid id)
    {
        var response = await http.GetAsync(FoodUrlApi.getId(id));
        return await response.ToResponse<Food>();
    }

    public async Task<Response<Food>> UpdateAsync(Food model)
    {
        var response = await http.PostAsJsonAsync(FoodUrlApi.update, model);
        return await response.ToResponse<Food>();
    }
}
