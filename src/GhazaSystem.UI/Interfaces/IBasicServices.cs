
using GhazaSystem.Common.Data;
using GhazaSystem.UI.Services;

namespace GhazaSystem.UI.Interfaces
{
    public interface IBasicServices
    {
        Task<Response<List<T>>> GetAllAsync<T>();
        Task<Response<T>> GetByIdAsync<T>(Guid id);
        Task<Response<User>> AddAsync<T>(T model);
        Task<Response<T>> UpdateAsync<T>(T model);
        Task<Response<object>> DeleteAsync<T>(Guid id);
        Task<Response<T>> GetByCodeAsync<T>(long code);
    }
}
