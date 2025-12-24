using GhazaSystem.Common.Data;
using GhazaSystem.Common.DTOs;

namespace GhazaSystem.UI.Interfaces
{
    public interface ICompanyServices
    {
        Task<Response<List<Company>>> GetAllAsync();
        Task<Response<Company>> GetByIdAsync(Guid id);
        Task<Response<Company>> AddAsync(CompanyDTOs model);
        Task<Response<Company>> UpdateAsync(Company model);
        Task<Response<object>> DeleteAsync(Guid id);
    }
}
