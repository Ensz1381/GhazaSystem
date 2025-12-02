using GhazaSystem.Common.DTOs;
using GhazaSystem.Api.Infrastructure;
using GhazaSystem.Api.Infrastructure.Data;
using GhazaSystem.Api.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


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

    public async Task<Response<User>> UpdateAsync(User user)
    {

        try
        {
            var result = await context.User.FirstOrDefaultAsync(x => x.Id == user.Id);
            result = context.User.Update(user).Entity;
            return ResponseBuilder.Success<User>(result);
        }

        catch (Exception ex)
        {
            return ResponseBuilder.Failure<User>(message:ex.Message);
        }
        finally
        {
            context.SaveChanges();

        }
    }
}
