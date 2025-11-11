using GhazaSystem.blazor.Interfaces;
using GhazaSystem.blazor.Shared;


namespace GhazaSystem.blazor.Services
{
    public class UserServices(HttpClient http) : IBasicServices
    {
        public async  Task<Response<T>> AddAsync<T>(T model)
        {
            var response = await http.PostAsJsonAsync(UserUrlApi.add, model);
            return await response.ToResponse<T>();
        }

        public Task<Response<object>> DeleteAsync<T>(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<T>>> GetAllAsync<T>()
        {
            throw new NotImplementedException();
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
