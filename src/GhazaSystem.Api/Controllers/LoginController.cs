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
        public async Task<IActionResult> All()
        {
            var logins = await loginRepository.GetAllAsync();
            return Ok(logins);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> delete(Guid id)
        {
            await loginRepository.DeleteAsync(id);
            return Ok();
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Login login)
        {
            await loginRepository.AddAsync(login);
            return Ok();
        }

        [HttpGet("get/{id}")]
        public async Task<Login> GetById(Guid id)
        {
            var login = await loginRepository.GetByIdAsync(id);
            if (login.Data == null) throw new Exception("is null");
            return login.Data;
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(Login login)
        {
            await loginRepository.UpdateAsync(login);
            return Ok();
        }
    }
}
