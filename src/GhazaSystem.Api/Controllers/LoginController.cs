using GhazaSystem.Api.DTOs;
using GhazaSystem.Api.Infrastructure.Data;
using GhazaSystem.Api.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GhazaSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    public class UserController(
    IInfrasructureRepository<Login> loginRepository
    ) : ControllerBase
    {
        [HttpGet("all")]
        public async Task<Response<List<Login>>> All()
        {
            var response = await loginRepository.GetAllAsync();
            if (response.IsSuccess == true) return ResponseBuilder.Success<List<Login>>(response.Data!);
            return ResponseBuilder.Failure<List<Login>>();
        }

        [HttpDelete("delete/{id}")]
        public async Task<Response<object>> delete(Guid id)
        {
            var response =  await loginRepository.DeleteAsync(id);
            if (response.IsSuccess == true) return ResponseBuilder.Success(response.Data!);
            return ResponseBuilder.Failure();
        }

        [HttpPost("add")]
        public async Task<Response<Login>> Add(Login login)
        {
            var response = await loginRepository.AddAsync(login);
            if (response.IsSuccess == true) return ResponseBuilder.Success<Login>(response.Data!);
            return ResponseBuilder.Failure<Login>();
        }

        [HttpGet("get/{id}")]
        public async Task<Response<Login>> GetById(Guid id)
        {
            var response = await loginRepository.GetByIdAsync(id);
            if (response.IsSuccess == true) return ResponseBuilder.Success<Login>(response.Data!);
            return ResponseBuilder.Failure<Login>();
        }

        [HttpPost("update")]
        public async Task<Response<Login>> Update(Login login)
        {
            var response = await loginRepository.UpdateAsync(login);
            if (response.IsSuccess == true) return ResponseBuilder.Success<Login>(response.Data!);
            return ResponseBuilder.Failure<Login>();
        }
    }
}
