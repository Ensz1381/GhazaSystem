using GhazaSystem.Common.Data;
using GhazaSystem.Common.DTOs;
using GhazaSystem.UI.Interfaces;
using GhazaSystem.UI.Shared;
using System.Reflection;
using System.Text.Json.Nodes;


namespace GhazaSystem.UI.Services
{
    public class UserServices(IHttpClientFactory httpClient) : IUserServices
    {
        private readonly HttpClient http = httpClient.CreateClient("api");
        public async  Task<Response<User>> AddAsync<T>(T model)
        {
            var response = await http.PostAsJsonAsync(UserUrlApi.add, model);
            return await response.ToResponse<User>();
        }

        public async Task<Response<object>> DeleteAsync<T>(Guid id)
        {
            var response = await http.DeleteAsync(UserUrlApi.delete(id));
            return await response.ToResponse<object>();
        }

        public async Task<Response<List<User>>> GetAllAsync<T>()
        {
            var response = await http.GetAsync(UserUrlApi.all);
            return await response.ToResponse<List<User>>();
        }

        public  async Task<Response<User>> GetByCodeAsync<T>(long code)
        {
            var response = await http.GetAsync(UserUrlApi.getCode(code));
            return await response.ToResponse<User>();
        }

        public async Task<Response<User>> GetByIdAsync<T>(Guid id)
        {
            var response = await http.GetAsync(UserUrlApi.getId(id));
            return await response.ToResponse<User>();
        }

        public async Task<Response<User>> UpdateAsync<T>(T model)
        {
            var response = await http.PostAsJsonAsync(UserUrlApi.update, model);
            return await response.ToResponse<User>();
        }
    }
}
