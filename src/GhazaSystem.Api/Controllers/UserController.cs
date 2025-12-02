using GhazaSystem.Api.Infrastructure.Data;
using GhazaSystem.Api.Interfaces;
using GhazaSystem.Api.Services;
using GhazaSystem.Common.DTOs;
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
        public async Task<Response<List<User>>?> All() {
            var users = await userRepository.GetAllAsync();
            if (users != null) return ResponseBuilder.Failure<List<User>>();
            
            return ResponseBuilder.Success<List<User>>(users!.Data!);
        }

        [HttpDelete("delete/{id}")]
        public async Task<Response<object>> delete (Guid id)
        {
            await userRepository.DeleteAsync(id);
            return ResponseBuilder.Success(message: "کاربر با موفقیت پاک شد.");
        }

        [HttpPost("add")]
        public async Task<Response<User>> Add(UserDTOs userdto)
        {
            User user = new User()
            {
                Id = new Guid(),
                First_Name = userdto.First_Name!,
                Last_Name = userdto.Last_Name!,
                National_Code = userdto.National_Code ,
            };

            return await userRepository.AddAsync(user);
        }

        [HttpGet("get/{id}")]
        public async Task<Response<User>> GetById(Guid id) 
        { 
            var user = await userRepository.GetByIdAsync(id);
            return ResponseBuilder.Success<User>(user.Data!);
        }

        [HttpPost("update")]
        public async Task<Response<object>> Update(User user)
        {
            await userRepository.UpdateAsync(user);
            return ResponseBuilder.Success();
        }

        [HttpGet("national-code/{code}")]
        public async Task<Response<User>> GetById(long code)
        {
            var result = await userRepository.GetAllAsync();
            var users = result.Data;

            if (users != null) {
                foreach (var user in users)
                {
                    if (user.National_Code == code)
                    {
                        return ResponseBuilder.Success<User>(user);
                    }
                }
            }
            return ResponseBuilder.Failure<User>( );
        }

    }
}
