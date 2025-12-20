using GhazaSystem.Common.Data;
using GhazaSystem.Common.DTOs;
using GhazaSystem.UI.Services;


namespace GhazaSystem.UI.Interfaces
{
    public interface IDailyFoodServices
    {
        Task<Response<List<Daily_Food>>> GetAllAsync();
        Task<Response<Daily_Food>> GetByIdAsync(Guid id);
        Task<Response<Daily_Food>> AddAsync(Daily_Food model);
        Task<Response<List<Daily_Food>>> AddListAsync(List<Daily_FoodDTOs> model);
        Task<Response<Daily_Food>> UpdateAsync(Daily_Food model);
        Task<Response<object>> DeleteAsync(Guid id);
        Task<Response<List<Daily_Food>>> GetMontAsync(int mont=0);
    }
}
