using GhazaSystem.Common.Data;
using GhazaSystem.Common.DTOs;
using GhazaSystem.UI.Interfaces;
using GhazaSystem.UI.Shared;


namespace GhazaSystem.UI.Services
{
    public class UserServices(IHttpClientFactory httpClient) : IBasicServices
    {
        private readonly HttpClient http = httpClient.CreateClient("api");
        public async  Task<Response<User>> AddAsync<T>(T model)
        {
            var response = await http.PostAsJsonAsync(UserUrlApi.add, model);
            return await response.ToResponse<User>();
        }

        public Task<Response<object>> DeleteAsync<T>(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<T>>> GetAllAsync<T>()
        {
            throw new NotImplementedException();
        }

        public  async Task<Response<T>> GetByCodeAsync<T>(long code)
        {
            var result = await http.GetAsync(UserUrlApi.getCode(code));
            return await result.ToResponse<T>();
        }

        public Task<Response<T>> GetByIdAsync<T>(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<T>> UpdateAsync<T>(T model)
        {
            throw new NotImplementedException();
        }
    }
}
