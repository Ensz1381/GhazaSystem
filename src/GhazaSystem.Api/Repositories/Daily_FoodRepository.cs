using GhazaSystem.Api.Infrastructure;
using GhazaSystem.Api.Infrastructure.Data;
using GhazaSystem.Api.Interfaces;
using GhazaSystem.Common.DTOs;
using Microsoft.EntityFrameworkCore;
using GhazaSystem.Common.Data;
using System.Security.Cryptography;

namespace GhazaSystem.Api.Services
{
    public class Daily_FoodRepository(GhazaDbContext context) : IInfrasructureRepository<Daily_Food>
    {
        public async Task<Response<Daily_Food>> AddAsync(Daily_Food model)
        {
            try
            {
                var result = await context.Daily_Foods.AddAsync(model);
                
                return ResponseBuilder.Success<Daily_Food>(model);
            }
            catch (Exception ex)
            {
                return ResponseBuilder.Failure<Daily_Food>(message:ex.Message);
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
                var result = await context.Daily_Foods.FirstOrDefaultAsync(x => x.Id == id);
                if (result == null) return ResponseBuilder.Failure(message: "notfound");
                result = context.Daily_Foods.Remove(result).Entity;
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

       
        

        public async Task<Response<List<Daily_Food>>> GetAllAsync()
        {
            try
            {
                var result = await context.Daily_Foods.ToListAsync();
                foreach (var item in result)
                {
                    item.food = await context.Food.FindAsync(item.foodId);
                }
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
                result.food = await context.Food.FindAsync(result.foodId);
                return ResponseBuilder.Success(result);
            }
            catch (Exception ex)
            {
                return ResponseBuilder.Failure<Daily_Food>(message: ex.Message);
            }
        }

        public async Task<Response<List<Daily_Food>>> GetListAsync(ListUserDailyFoodsDTO model)
        {
            try
            {
                var res = await context.User
                    .Where(u=>u.Id == model.UserId)
                .Select(
                    S=> new User
                    {
                        Id = S.Id,
                        First_Name = S.First_Name,
                        Last_Name = S.Last_Name,
                        National_Code = S.National_Code,
                        Daily_Foods = S.Daily_Foods
                            .Where(df => df.Mount ==  model.Mount)
                            .Select(F => new Daily_Food
                            {
                                Id =F.Id,
                                Date = F.Date,
                                food = F.food,
                                foodId = F.foodId,
                                Mount = F.Mount
                            })
                            .ToList()
                    }
                    ).FirstOrDefaultAsync();

                var resDailyFoods = res.Daily_Foods;
                return ResponseBuilder.Success<List<Daily_Food>>(resDailyFoods!.ToList());
            }
            catch(Exception ex)
            {
                return ResponseBuilder.Failure<List<Daily_Food>>(message:ex.Message);
            }
        }

        public Task<Response<object>> SetListAsync(ListUserDailyFoodsDTO list)
        {
            throw new NotImplementedException();
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
            finally
            {
                context.SaveChanges();

            }
        }

    }
}
