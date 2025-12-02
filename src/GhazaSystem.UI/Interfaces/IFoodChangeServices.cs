


using GhazaSystem.Common.Data;
using GhazaSystem.Common.DTOs;
using GhazaSystem.UI.Services;

namespace GhazaSystem.UI.Interfaces;

public interface IFoodChangeServices
{
    Task<Response<List<Food_Change>>> GetAllAsync();
    Task<Response<Food_Change>> GetByIdAsync(Guid id);
    Task<Response<Food_Change>> AddAsync(Food_Change model);
    Task<Response<Food_Change>> UpdateAsync(Food_Change model);
    Task<Response<object>> DeleteAsync(Guid id);
}
