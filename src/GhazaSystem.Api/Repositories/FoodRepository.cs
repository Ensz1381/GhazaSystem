using GhazaSystem.Common.DTOs;
using GhazaSystem.Api.Infrastructure;
using GhazaSystem.Api.Infrastructure.Data;
using GhazaSystem.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GhazaSystem.Api.Services
{
    public class FoodRepository(GhazaDbContext context) : IInfrasructureRepository<Food>
    {
        public async Task<Response<Food>> AddAsync(Food model)
        {
            try
            {
                var result = await context.Food.AddAsync(model);
                return ResponseBuilder.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBuilder.Failure<Food>(message: ex.ToString());
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
                var result = await context.Food.FindAsync(id);
                result = (result != null) ? context.Food.Remove(result).Entity : throw new Exception("An error occurred while deleting the food change.");
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


        public async Task<Response<List<Food>>> GetAllAsync()
        {
            try
            {
                var result = await context.Food.ToListAsync();
                return ResponseBuilder.Success(result);
            }
            catch (Exception ex)
            {
                return ResponseBuilder.Failure<List<Food>>(message:ex.ToString());
            }
        }

        public async Task<Response<Food>> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await context.Food.FirstOrDefaultAsync(x => x.Id == id);
                return (result != null) ? ResponseBuilder.Success(result) : ResponseBuilder.Failure<Food>(message:"notfound");

            }
            catch (Exception ex)
            {
                return ResponseBuilder.Failure<Food>(message:ex.ToString());
            }
        }

        public async Task<Response<Food>> UpdateAsync(Food model)
        {
            try
            {
                var result = await context.Food.FirstOrDefaultAsync(x => x.Id == model.Id);
                result = context.Food.Update(model).Entity;
                return ResponseBuilder.Success(result);
            }

            catch (Exception ex)
            {
                return ResponseBuilder.Failure<Food>(message: ex.ToString());
            }
            finally
            {
                context.SaveChanges();

            }
        }


    }
}
