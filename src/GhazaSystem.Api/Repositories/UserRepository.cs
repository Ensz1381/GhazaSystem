using GhazaSystem.Common.DTOs;
using GhazaSystem.Api.Infrastructure;
using GhazaSystem.Api.Infrastructure.Data;
using GhazaSystem.Api.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GhazaSystem.Common.Data;

namespace GhazaSystem.Api.Services;

public class UserRepository(GhazaDbContext context) : IInfrasructureRepository<User>
{
    public async Task<Response<User>> AddAsync(User user)
    {

        try
        {
            var result = await context.User.AddAsync(user);
            return ResponseBuilder.Success<User>(user,message:result.ToString());
        }
        catch (Exception ex)
        {
            return ResponseBuilder.Failure<User>(message:ex.Message);
        }
        finally {
            context.SaveChanges();
        
        }
    }

    public async Task<Response<object>> DeleteAsync(Guid id)
    {
        try
        {
            var result = await context.User.FindAsync(id);
            result = (result != null) ? context.User.Remove(result).Entity : throw new Exception("An error occurred while deleting the food change.");
            return ResponseBuilder.Success<object>(result);
        }
        catch (Exception ex)
        {
            return ResponseBuilder.Failure(message:ex.Message);
        }
        finally
        {
            context.SaveChanges();

        }
    }

    public async Task<Response<List<User>>> GetAllAsync()
    {
        try
        {
            var result = await context.User.ToListAsync();
            if (result == null)
            {
                return ResponseBuilder.Failure<List<User>>(message: "is null");
            }
            return ResponseBuilder.Success<List<User>>(result);
        }
        catch (Exception ex)
        {
            return ResponseBuilder.Failure<List<User>>(message:ex.Message);
        }




    }

    public async Task<Response<User>> GetByIdAsync(Guid id)
    {
        try
        {
            var result = await context.User.FirstOrDefaultAsync(x => x.Id == id);
            return (result != null) ? ResponseBuilder.Success<User>(result) : ResponseBuilder.Failure<User>(message:"is null");

        }
        catch (Exception ex)
        {
            return ResponseBuilder.Failure<User>(message:ex.Message);

        }

    }

    public Task<Response<List<User>>> GetListAsync(ListUserDailyFoodsDTO model)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<object>> SetListAsync(ListUserDailyFoodsDTO list)
    {
        /*
            var user = await context.User
                .Include(u => u.Daily_Foods)
                .FirstOrDefaultAsync(u => u.Id == list.UserId);
            if (user == null || user.Daily_Foods == null) return ResponseBuilder.Failure(message: "کاربر یا غذای روزی برای کاربر پیدا نشد");
            var removeitem = user.Daily_Foods.Where(d => d.Mount == list.Mount).ToList();


            foreach (var item in removeitem)
            {
                user.Daily_Foods.Remove(item);
             }
        if (list.ListDailyFoods == null) return ResponseBuilder.Failure(message: " غذای روزی برای کاربر انتخاب نشده");
            foreach (var item in list.ListDailyFoods!)
            {
                user.Daily_Foods.Add(item);
            }
        try
        {
            await context.SaveChangesAsync();
            return ResponseBuilder.Success();
        }catch(Exception ex)
        {
           return ResponseBuilder.Failure(message: ex.Message );
        }
        */

        try
        {
            var DataBaseDailyFood = await context.Daily_Foods
            .Include(u => u.users)
            .Where(d => d.Mount == list.Mount)
            .ToListAsync();

            var userlist = await context.User.FirstOrDefaultAsync(x => x.Id == list.UserId);
            if (DataBaseDailyFood == null || DataBaseDailyFood.Count <= 0) return ResponseBuilder.Failure(message: "کاربر یا غذای روزی برای کاربر پیدا نشد");

            foreach (var daily in DataBaseDailyFood)
            {
                bool addnow = false;
                bool haveuser = false;
                if (daily != null && userlist != null )
                {
                    if(daily.users != null)
                    foreach (var user in daily.users)
                    {
                        if (user.Id == list.UserId) haveuser = true;
                    }
                    foreach (var item in list.ListDailyFoods!)
                    {
                        if (daily != null && daily.Id == item.Id) addnow = true;

                    }
                    if (addnow && !haveuser) daily!.users!.Add(userlist);
                    if (!addnow && haveuser) daily!.users!.Remove(userlist);
                }
            }

            await context.SaveChangesAsync();
            return ResponseBuilder.Success();

        }
        catch (Exception ex)
        {
            return ResponseBuilder.Failure(message: ex.Message);
        }
    }

    public async Task<Response<User>> UpdateAsync(User user)
    {

        try
        {
            
            context.User.Attach(user);
            context.Entry(user).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return ResponseBuilder.Success<User>(user);
        }

        catch (Exception ex)
        {
            return ResponseBuilder.Failure<User>(message:ex.Message+".........2");
        }
       

    }
}
