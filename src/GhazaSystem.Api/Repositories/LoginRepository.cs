using GhazaSystem.Common.DTOs;
using GhazaSystem.Api.Infrastructure;
using GhazaSystem.Api.Infrastructure.Data;
using GhazaSystem.Api.Interfaces;
using Microsoft.EntityFrameworkCore;
using GhazaSystem.Common.Data;

namespace GhazaSystem.Api.Services
{
    public class LoginRepository(GhazaDbContext context) : IInfrasructureRepository<Login>
    {
        public async Task<Response<Login>> AddAsync(Login model)
        {
            try
            {
                var result = await context.Login.AddAsync(model);
                return ResponseBuilder.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBuilder.Failure<Login>(message: ex.ToString());
            }
            finally
            {
                context.SaveChanges();

            }
        }


        public async Task<Response<object>> DeleteAsync(Guid id)
        {
            try
            {
                var result = await context.Login.FindAsync(id);
                result = (result != null) ? context.Login.Remove(result).Entity : throw new Exception("An error occurred while deleting the food change.");
                return ResponseBuilder.Success<object>(result);
            }
            catch (Exception ex)
            {
                return ResponseBuilder.Failure(message: ex.ToString());
            }
            finally
            {
                context.SaveChanges();

            }
        }


        public async Task<Response<List<Login>>> GetAllAsync()
        {
            try
            {
                var result = await context.Login.ToListAsync();
                return ResponseBuilder.Success(result);
            }
            catch (Exception ex)
            {
                return ResponseBuilder.Failure<List<Login>>(message: ex.ToString());
            }
        }

        public async Task<Response<Login>> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await context.Login.FirstOrDefaultAsync(x => x.Id == id);
                return (result != null) ? ResponseBuilder.Success(result) : ResponseBuilder.Failure<Login>(message: "notfound");

            }
            catch (Exception ex)
            {
                return ResponseBuilder.Failure<Login>(message: ex.ToString());
            }
        }

        public Task<Response<List<Login>>> GetListAsync(ListUserDailyFoodsDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<object>> SetListAsync(List<Login> list)
        {
            throw new NotImplementedException();
        }

        public Task<Response<object>> SetListAsync(ListUserDailyFoodsDTO list)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<Login>> UpdateAsync(Login model)
        {
            try
            {
                var result = await context.Login.FirstOrDefaultAsync(x => x.Id == model.Id);
                result = context.Login.Update(model).Entity;
                return ResponseBuilder.Success(result);
            }

            catch (Exception ex)
            {
                return ResponseBuilder.Failure<Login>(message: ex.ToString());
            }
            finally
            {
                context.SaveChanges();

            }
        }

    }
}
