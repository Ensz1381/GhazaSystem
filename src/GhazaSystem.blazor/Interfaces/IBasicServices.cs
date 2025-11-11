
using GhazaSystem.blazor.Services;

namespace GhazaSystem.blazor.Interfaces
{
    public interface IBasicServices
    {
        Task<Response<List<T>>> GetAllAsync<T>();
        Task<Response<T>> GetByIdAsync<T>(Guid id);
        Task<Response<T>> AddAsync<T>(T model);
        Task<Response<T>> UpdateAsync<T>(T model);
        Task<Response<object>> DeleteAsync<T>(Guid id);
    }
}
