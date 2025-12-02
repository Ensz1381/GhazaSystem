using GhazaSystem.Common.Data;
using GhazaSystem.Common.DTOs;
using GhazaSystem.UI.Interfaces;
using GhazaSystem.UI.Shared;
using System.Net.Http;

namespace GhazaSystem.UI.Services
{
    public class FoodChangeServices(IHttpClientFactory httpClient) : IFoodChangeServices
    {
        private readonly HttpClient http = httpClient.CreateClient("api");

        public async Task<Response<Food_Change>> AddAsync(Food_Change model)
        {
            var response = await http.PostAsJsonAsync(Food_changeUrlApi.add, model);
            return await response.ToResponse<Food_Change>();
        }

        public async Task<Response<object>> DeleteAsync(Guid id)
        {
            var response = await http.DeleteAsync(Food_changeUrlApi.delete(id));
            return await response.ToResponse<object>();
        }

        public async Task<Response<List<Food_Change>>> GetAllAsync()
        {
            var response = await http.GetAsync(Food_changeUrlApi.all);
            return await response.ToResponse<List<Food_Change>>();
        }

        public async Task<Response<Food_Change>> GetByIdAsync(Guid id)
        {
            var response = await http.GetAsync(Food_changeUrlApi.getId(id));
            return await response.ToResponse<Food_Change>();
        }

        public async Task<Response<Food_Change>> UpdateAsync(Food_Change model)
        {
            var response = await http.PostAsJsonAsync(Food_changeUrlApi.update, model);
            return await response.ToResponse<Food_Change>();
        }
    }
}
