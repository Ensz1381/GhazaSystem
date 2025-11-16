

using GhazaSystem.Common.Data;
using GhazaSystem.UI.Services;

namespace GhazaSystem.UI.Interfaces;

public interface IFoodServices
{
    Task<Response<List<Food>>> GetAllAsync();
    Task<Response<Food>> GetByIdAsync(Guid id);
    Task<Response<Food>> AddAsync(Food model);
    Task<Response<Food>> UpdateAsync(Food model);
    Task<Response<object>> DeleteAsync(Guid id);
}
