using GhazaSystem.Common.Data;
using GhazaSystem.Common.DTOs;
using GhazaSystem.UI.Interfaces;
using GhazaSystem.UI.Shared;
using System.Net.Http;

namespace GhazaSystem.UI.Services
{
    public class DailyFoodServices(IHttpClientFactory httpClient) : IDailyFoodServices
    {
        private readonly HttpClient http = httpClient.CreateClient("api");
        public async Task<Response<Daily_Food>> AddAsync(Daily_Food model)
        {
            var response = await http.PostAsJsonAsync(Daily_FoodUrlApi.add, model);
            return await response.ToResponse<Daily_Food>();
        }

        public async Task<Response<object>> DeleteAsync(Guid id)
        {
            var response = await http.DeleteAsync(Daily_FoodUrlApi.delete(id));
            return await response.ToResponse<object>();
        }

        public async Task<Response<List<Daily_Food>>> GetAllAsync()
        {
            var response = await http.GetAsync(Daily_FoodUrlApi.all);
            return await response.ToResponse<List<Daily_Food>>();
        }

        public async Task<Response<Daily_Food>> GetByIdAsync(Guid id)
        {
            var response = await http.GetAsync(Daily_FoodUrlApi.getId(id));
            return await response.ToResponse<Daily_Food>();
        }

        public async Task<Response<Daily_Food>> UpdateAsync(Daily_Food model)
        {
            var response = await http.PostAsJsonAsync(Daily_FoodUrlApi.update, model);
            return await response.ToResponse<Daily_Food>();
        }
    }
}
