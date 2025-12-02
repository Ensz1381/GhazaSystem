using GhazaSystem.Common.DTOs;
using GhazaSystem.Api.Infrastructure;
using GhazaSystem.Api.Infrastructure.Data;
using GhazaSystem.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GhazaSystem.Api.Services
{
    public class Food_ChangeRepository(GhazaDbContext context) : IInfrasructureRepository<Food_Change>
    {
        public async Task<Response<Food_Change>> AddAsync(Food_Change model)
        {
            try
            {
                var result = await context.Food_Change.AddAsync(model);
                return ResponseBuilder.Success<Food_Change>(model,message:result.ToString());
            }
            catch (Exception ex)
            {
                return ResponseBuilder.Failure<Food_Change>(message:ex.Message);
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
                var result = await context.Food_Change.FirstOrDefaultAsync(x => x.Id == id);
                if (result == null) return ResponseBuilder.Failure(message: "notfound");
                result =  context.Food_Change.Remove(result).Entity ;
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


        public async Task<Response<List<Food_Change>>> GetAllAsync()
        {
            try
            {
                var result = await context.Food_Change.ToListAsync();
                return ResponseBuilder.Success(result);
            }
            catch (Exception ex)
            {
                return ResponseBuilder.Failure<List<Food_Change>>(message:ex.Message);
            }
        }

        public async Task<Response<Food_Change>> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await context.Food_Change.FirstOrDefaultAsync(x => x.Id == id);
                return (result != null) ? ResponseBuilder.Success(result) : ResponseBuilder.Failure<Food_Change>(message:"notfound");

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the food change.", ex);
            }
        }


        public async Task<Response<Food_Change>> UpdateAsync(Food_Change model)
        {
            try
            {
                var result = await context.Food_Change.FirstOrDefaultAsync(x => x.Id == model.Id);
                result = context.Food_Change.Update(model).Entity;
                return ResponseBuilder.Success<Food_Change>(result);
            }

            catch (Exception ex)
            {
                return ResponseBuilder.Failure<Food_Change>(message:ex.Message);
            }
            finally
            {
                context.SaveChanges();

            }
        }

    }
}
