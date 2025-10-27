using GhazaSystem.Api.DTOs;
using GhazaSystem.Api.Infrastructure;
using GhazaSystem.Api.Infrastructure.Data;
using GhazaSystem.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GhazaSystem.Api.Services
{
    public class Daily_FoodRepository(GhazaDbContext context) : IInfrasructureRepository<Daily_Food>
    {
        public async Task<Response<Daily_Food>> AddAsync(Daily_Food model)
        {
            try
            {
                var result = await context.Daily_Foods.AddAsync(model).AsTask();
                return ResponseBuilder.Success<Daily_Food>(model);
            }
            catch (Exception ex)
            {
                return ResponseBuilder.Failure<Daily_Food>(message:ex.Message);
            }
        }

        public async Task<Response<object>> DeleteAsync(Guid id)
        {
            try
            {
                var result = await context.Daily_Foods.FirstOrDefaultAsync(x => x.Id == id);
                if (result == null) return ResponseBuilder.Failure(message: "notfound");
                result = context.Daily_Foods.Remove(result).Entity;
                return ResponseBuilder.Success<object>(result);
            }
            catch (Exception ex)
            {
                return ResponseBuilder.Failure(message:ex.Message);
            }
        }

        public async Task<Response<List<Daily_Food>>> GetAllAsync()
        {
            try
            {
                var result = await context.Daily_Foods.ToListAsync();
                return ResponseBuilder.Success(result);
            }
            catch (Exception ex)
            {
                return ResponseBuilder.Failure<List<Daily_Food>>(message:ex.Message);
            }
        }

        public async Task<Response<Daily_Food>> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await context.Daily_Foods.FirstOrDefaultAsync(x => x.Id == id);
                if (result == null) return ResponseBuilder.Failure<Daily_Food>(message: "notfound");
                return ResponseBuilder.Success(result);
            }
            catch (Exception ex)
            {
                return ResponseBuilder.Failure<Daily_Food>(message: ex.Message);
            }
        }

        public async Task<Response<Daily_Food>> UpdateAsync(Daily_Food model)
        {
            try
            {
                var result = await context.Daily_Foods.FirstOrDefaultAsync(x => x.Id == model.Id);
                result = context.Daily_Foods.Update(model).Entity;
                return ResponseBuilder.Success(result);
            }
            catch (Exception ex)
            {
                return ResponseBuilder.Failure<Daily_Food>(message: ex.Message);

            }
        }

    }
}
