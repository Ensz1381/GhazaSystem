using GhazaSystem.Api.Infrastructure.Data;
using GhazaSystem.Api.Interfaces;
using GhazaSystem.Api.Services;
using GhazaSystem.Common.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GhazaSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Food_ChangeController(
    IInfrasructureRepository<Food_Change> food_changeRepository
    ) : ControllerBase
{
    [HttpGet("all")]
    public async Task<Response<List<Food_Change>>> All()
    {
        var response = await food_changeRepository.GetAllAsync();
        if(response.IsSuccess==true) return ResponseBuilder.Success(response.Data!);
        return ResponseBuilder.Failure<List<Food_Change>>();
    }

    [HttpDelete("delete/{id}")]
    public async Task<Response<object>> delete(Guid id)
    {
        var response =  await food_changeRepository.DeleteAsync(id);
        if (response.IsSuccess == true) return ResponseBuilder.Success();
        return ResponseBuilder.Failure<object>();
    }

    [HttpPost("add")]
    public async Task<Response<Food_Change>> Add(Food_Change model)
    {
        var response =  await food_changeRepository.AddAsync(model);
       if (response.IsSuccess == true) return ResponseBuilder.Success<Food_Change>(response.Data!);
        return ResponseBuilder.Failure<Food_Change>();
    }

    [HttpGet("get/{id}")]
    public async Task<Response<Food_Change>> GetById(Guid id)
    {
        var response = await food_changeRepository.GetByIdAsync(id);
        if (response.IsSuccess == true) return ResponseBuilder.Success<Food_Change>(response.Data!);
        return ResponseBuilder.Failure<Food_Change>();
    }

    [HttpPost("update")]
    public async Task<Response<Food_Change>> Update(Food_Change model)
    {
        var response = await food_changeRepository.UpdateAsync(model);
        if (response.IsSuccess == true) return ResponseBuilder.Success<Food_Change>(response.Data!);
        return ResponseBuilder.Failure<Food_Change>();
    }
}
