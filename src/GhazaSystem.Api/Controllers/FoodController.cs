using GhazaSystem.Api.Infrastructure.Data;
using GhazaSystem.Api.Interfaces;
using GhazaSystem.Common.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GhazaSystem.Common.Data;

namespace GhazaSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FoodController(
    IInfrasructureRepository<Food> FoodRepository
    ) : ControllerBase
{
    [HttpGet("all")]
    public async Task<Response<List<Food>>> All()
    {
        var respons = await FoodRepository.GetAllAsync();
        return ResponseBuilder.Success<List<Food>>(respons.Data!);
    }

    [HttpDelete("delete/{id}")]
    public async Task<Response<object>> delete(Guid id)
    {
        var response = await FoodRepository.DeleteAsync(id);
        if(response.IsSuccess==true) return ResponseBuilder.Success();
        return ResponseBuilder.Failure<object>();
    }

    [HttpPost("add")]
    public async Task<Response<Food>> Add(FoodDTOs model)
    {
        var food_model =  new Food() { Amount = model.Amount,Name= model.Name,Description=model.Description,Id = new Guid(),Photos = model.Photos }; 
        var response = await FoodRepository.AddAsync(food_model);
        if (response.IsSuccess==true) return ResponseBuilder.Success(response.Data!);
        return ResponseBuilder.Failure<Food>();
    }

    [HttpGet("get/{id}")]
    public async Task<Response<Food>> GetById(Guid id)
    {
        var response = await FoodRepository.GetByIdAsync(id);
        if (response.Data == null) ResponseBuilder.Failure<Food>();
        return ResponseBuilder.Success(response.Data!);
    }

    [HttpPost("update")]
    public async Task<Response<Food>> Update(Food model)
    {
        var response = await FoodRepository.UpdateAsync(model);
        if (response.IsSuccess == true) return ResponseBuilder.Success(response.Data!);
        return ResponseBuilder.Failure<Food>();
    }
    
}