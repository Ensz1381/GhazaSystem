using GhazaSystem.Api.Infrastructure;
using GhazaSystem.Api.Interfaces;
using GhazaSystem.Common.Data;
using GhazaSystem.Common.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GhazaSystem.Api.Repositories
{
    public class CompanyRepository(GhazaDbContext context) : IInfrasructureRepository<Company>
    {
        public async Task<Response<Company>> AddAsync(Company model)
        {
            try
            {
                var result = await context.Companies.AddAsync(model);
                return ResponseBuilder.Success<Company>(model, message: result.ToString());
            }
            catch (Exception ex)
            {
                return ResponseBuilder.Failure<Company>(message: ex.Message);
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
                var result = await context.Companies.FindAsync(id);
                result = (result != null) ? context.Companies.Remove(result).Entity : throw new Exception("An error occurred while deleting the food change.");
                return ResponseBuilder.Success<object>(result);
            }
            catch (Exception ex)
            {
                return ResponseBuilder.Failure(message: ex.Message);
            }
            finally
            {
                context.SaveChanges();

            }
        }

        public async Task<Response<List<Company>>> GetAllAsync()
        {
            try
            {
                var result = await context.Companies.ToListAsync();
                if (result == null)
                {
                    return ResponseBuilder.Failure<List<Company>>(message: "is null");
                }
                return ResponseBuilder.Success<List<Company>>(result);
            }
            catch (Exception ex)
            {
                return ResponseBuilder.Failure<List<Company>>(message: ex.Message);
            }


        }

        public async Task<Response<Company>> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await context.Companies.FirstOrDefaultAsync(x => x.Id == id);
                return (result != null) ? ResponseBuilder.Success<Company>(result) : ResponseBuilder.Failure<Company>(message: "is null");

            }
            catch (Exception ex)
            {
                return ResponseBuilder.Failure<Company>(message: ex.Message);

            }
        }

        public Task<Response<List<Company>>> GetListAsync(ListUserDailyFoodsDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<object>> SetListAsync(ListUserDailyFoodsDTO list)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<Company>> UpdateAsync(Company model)
        {
            try
            {

                context.Companies.Attach(model);
                context.Entry(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return ResponseBuilder.Success<Company>(model);
            }

            catch (Exception ex)
            {
                return ResponseBuilder.Failure<Company>(message: ex.Message + ".........2");
            }

        }
    }
}
