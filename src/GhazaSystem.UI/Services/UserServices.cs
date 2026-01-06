using GhazaSystem.Common.Data;
using GhazaSystem.Common.DTOs;
using GhazaSystem.UI.Interfaces;
using GhazaSystem.UI.Shared;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using MudBlazor;
using System.Reflection;
using System.Text.Json.Nodes;


namespace GhazaSystem.UI.Services
{
    public class UserServices(IHttpClientFactory httpClient, ProtectedLocalStorage Storage) : IUserServices
    {
        public User? LocalUser { get; set; } = null;
        private readonly HttpClient http = httpClient.CreateClient("api");
        public async  Task<Response<User>> AddAsync<T>(T model)
        {
            var response = await http.PostAsJsonAsync(UserUrlApi.add, model);
            return await response.ToResponse<User>();
        }

        public async Task<Response<object>> DeleteAsync<T>(Guid id)
        {
            var response = await http.DeleteAsync(UserUrlApi.delete(id));
            return await response.ToResponse<object>();
        }

        public async Task<Response<List<User>>> GetAllAsync<T>()
        {
            var response = await http.GetAsync(UserUrlApi.all);
            return await response.ToResponse<List<User>>();
        }

        public  async Task<Response<User>> GetByCodeAsync<T>(long code)
        {
            var response = await http.GetAsync(UserUrlApi.getCode(code));
            return await response.ToResponse<User>();
        }

        public async Task<Response<User>> GetByIdAsync<T>(Guid id)
        {
            var response = await http.GetAsync(UserUrlApi.getId(id));
            return await response.ToResponse<User>();
        }

        public async Task<Response<User>> UpdateAsync(User model)
        {
            var response = await http.PostAsJsonAsync(UserUrlApi.update, model);
            return await response.ToResponse<User>();
        }
        public async Task<Response<object>> UpdateDailyFoodAsync(ListUserDailyFoodsDTO model)
        {
            var responce = await http.PostAsJsonAsync(UserUrlApi.updateDailyFood, model);
            return await responce.ToResponse<object>();
        }

        public async Task<Response<User>> SetLocalUser(long Code)
        {
            if (long.IsPositive(Code))
            {
                var result = await GetByCodeAsync<User>(Code);
                if (result.Data == null || !result.IsSuccess || result.Data.National_Code == 0) return ResponseBuilder.Failure<User>() ;
                await Storage.SetAsync("User", result.Data);
                LocalUser = result.Data;
                return ResponseBuilder.Success<User>(LocalUser!) ;
            }
            return ResponseBuilder.Failure<User>();
        }
        
        public async Task<Response<object>> SetAccess(UserAccess UA)
        {
            var result = await http.PostAsJsonAsync(UserUrlApi.SetAccessUser, UA);
            if (result.IsSuccessStatusCode) return ResponseBuilder.Success();
            return ResponseBuilder.Failure();
        }


    }
}
