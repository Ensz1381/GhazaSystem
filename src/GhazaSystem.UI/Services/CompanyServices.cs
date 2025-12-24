using GhazaSystem.Common.Data;
using GhazaSystem.Common.DTOs;
using GhazaSystem.UI.Interfaces;
using GhazaSystem.UI.Shared;

namespace GhazaSystem.UI.Services
{
    public class CompanyServices(IHttpClientFactory httpClient) : ICompanyServices
    {
        private readonly HttpClient http = httpClient.CreateClient("api");
        public async Task<Response<Company>> AddAsync(CompanyDTOs model)
        {
            var response = await http.PostAsJsonAsync(CompanyUrlApi.add, model);
            return await response.ToResponse<Company>();
        }

        public async Task<Response<object>> DeleteAsync(Guid id)
        {
            var response = await http.DeleteAsync(CompanyUrlApi.delete(id));
            return await response.ToResponse<object>();
        }

        public async Task<Response<List<Company>>> GetAllAsync()
        {
            var response = await http.GetAsync(CompanyUrlApi.all);
            return await response.ToResponse<List<Company>>();
        }

        public async Task<Response<Company>> GetByIdAsync(Guid id)
        {
            var response = await http.GetAsync(CompanyUrlApi.getId(id));
            return await response.ToResponse<Company>();
        }

        public async Task<Response<Company>> UpdateAsync(Company model)
        {
            var response = await http.PostAsJsonAsync(CompanyUrlApi.update, model);
            return await response.ToResponse<Company>();
        }
    }
}
