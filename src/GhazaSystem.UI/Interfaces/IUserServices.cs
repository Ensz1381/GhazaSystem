
using GhazaSystem.Common.Data;
using GhazaSystem.Common.DTOs;
using GhazaSystem.UI.Services;

namespace GhazaSystem.UI.Interfaces
{
    public interface IUserServices
    {
        Task<Response<List<User>>> GetAllAsync<T>();
        Task<Response<User>> GetByIdAsync<T>(Guid id);
        Task<Response<User>> AddAsync<T>(T model);
        Task<Response<User>> UpdateAsync(User model);
        Task<Response<object>> DeleteAsync<T>(Guid id);
        Task<Response<User>> GetByCodeAsync<T>(long code);
        Task<Response<User>> SetLocalUser(long Code);
    }
}
