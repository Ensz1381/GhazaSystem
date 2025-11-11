
using GhazaSystem.Api.DTOs;
using GhazaSystem.Api.Infrastructure.Data;
using GhazaSystem.Api.Interfaces;
using GhazaSystem.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GhazaSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(
        IInfrasructureRepository<User> userRepository
        ) : ControllerBase
    {
        [HttpGet("all")]
        public async Task<IActionResult> All() {
            var users = await userRepository.GetAllAsync();
            return Ok(users);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> delete (Guid id)
        {
            await userRepository.DeleteAsync(id);
            return Ok();
        }

        [HttpPost("add")]
        public async Task<Response<User>> Add(UserDTOs userdto)
        {
            User user = new User()
            {
                Id = new Guid(),
                First_Name = userdto.First_Name,
                Last_Name = userdto.Last_Name,
                National_Code = userdto.National_Code ,
            };

            return await userRepository.AddAsync(user);
        }

        [HttpGet("get/{id}")]
        public async Task<User> GetById(Guid id) 
        { 
            var user = await userRepository.GetByIdAsync(id);
            return user.Data;
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(User user)
        {
            await userRepository.UpdateAsync(user);
            return Ok();
        }

        [HttpGet("national-code/{code}")]
        public async Task<User> GetById(long code)
        {
            var result = await userRepository.GetAllAsync();
            var users = result.Data;

            if (users != null) {
                foreach (var user in users)
                {
                    if (user.National_Code == code)
                    {
                        return user;
                    }
                }
            }
            return new User() { Id = new Guid(),First_Name = "nuul",Last_Name="null",National_Code = 0 };
        }

    }
}
