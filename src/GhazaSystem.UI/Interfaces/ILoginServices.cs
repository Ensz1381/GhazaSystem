using GhazaSystem.Common.Data;
using GhazaSystem.Common.DTOs;
using GhazaSystem.UI.Services;


namespace GhazaSystem.UI.Interfaces;

public interface ILoginServices
{
    Task<Response<List<Login>>> GetAllAsync();
    Task<Response<Login>> GetByIdAsync(Guid id);
    Task<Response<Login>> AddAsync(Login model);
    Task<Response<Login>> UpdateAsync(Login model);
    Task<Response<object>> DeleteAsync(Guid id);
}
