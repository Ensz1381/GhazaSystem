using GhazaSystem.Api.Infrastructure.Data;
using GhazaSystem.Api.Interfaces;
using GhazaSystem.Api.Services;
using GhazaSystem.Common.Data;
using GhazaSystem.Common.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GhazaSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(
    IInfrasructureRepository<User> userRepository
    ) : ControllerBase
{
    [HttpGet("all")]
    public async Task<Response<List<User>>> All() {
        var users = await userRepository.GetAllAsync();
        if (users == null) return ResponseBuilder.Failure<List<User>>();
        
        return ResponseBuilder.Success<List<User>>(users.Data!);
    }

    [HttpDelete("delete/{id}")]
    public async Task<Response<object>> delete (Guid id)
    {
        await userRepository.DeleteAsync(id);
       
        return ResponseBuilder.Success(message: "کاربر با موفقیت پاک شد.");
    }
    [HttpDelete("deletedaily/{id}/{mont}")]
    public async Task<Response<object>> deleteDaily(Guid id,int mont)
    {
        ListUserDailyFoodsDTO model = new ListUserDailyFoodsDTO() { UserId = id, Mount = mont};
        var result = await userRepository.SetListAsync(model);

        return ResponseBuilder.Success(message: "غذا های کاربر با موفقیت پاک شد" + result.Message);
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

    [HttpPost("updatedaily")]
    public async Task<Response<object>> UpdateDaily(ListUserDailyFoodsDTO model)
    {
        try
        {
            var resremove = await userRepository.SetListAsync(model);
            if (resremove.IsSuccess != true) return  ResponseBuilder.Failure(message: "حذف غذای کاربران به مشکل خورد"+resremove!.Message);
            //Guid guid = (Guid)model.UserId!;
            //var responce = await userRepository.GetByIdAsync(guid);
            //User user = responce.Data!;
            //user.Daily_Foods = model.ListDailyFoods;
            //Console.WriteLine("..............................");
            //Console.WriteLine(user.Daily_Foods!.Count.ToString() +"..............................");
            //if (user.Daily_Foods != null)
            //{
            //    foreach (var food in model.ListDailyFoods)
            //    {
             //       Console.WriteLine(food.food.Name + "number food :" + food.food.Id +"number daily food :"+food.Id+ food.Date.ToString() + food.Mount + "..............................");
            //    }
            //}

            //Console.WriteLine("..............................");
            //await userRepository.UpdateAsync(user);
            return ResponseBuilder.Success();
        }
        catch (Exception ex)
        {
            return ResponseBuilder.Failure(message: ex.Message);
        }
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

    [HttpPost("setaccess")]
    public async Task<Response<object>> SetAccess(UserAccess UA)
    {
        var result = await userRepository.GetByIdAsync(UA.userId);
        var User = result.Data;
        if (User == null) return ResponseBuilder.Failure(message: "کاربر یافت نشد");
        User.Access = UA.accessList;
        var update = await userRepository.UpdateAsync(User);
        return ResponseBuilder.Success(message: update.Message!);

    }
}
