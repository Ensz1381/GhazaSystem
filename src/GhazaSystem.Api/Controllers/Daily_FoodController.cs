using GhazaSystem.Api.Infrastructure.Data;
using GhazaSystem.Api.Interfaces;
using GhazaSystem.Common.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GhazaSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Daily_FoodController(
    IInfrasructureRepository<Daily_Food> Daily_FoodRepository
    ) : ControllerBase
{
    [HttpGet("all")]
    public async Task<Response<List<Daily_Food>>> All()
    {
        var response = await Daily_FoodRepository.GetAllAsync();
        if(response.IsSuccess == true)  return ResponseBuilder.Success(response.Data!);
        return ResponseBuilder.Failure<List<Daily_Food>>();
    }

    [HttpDelete("delete/{id}")]
    public async Task<Response<object>> delete(Guid id)
    {
        var response = await Daily_FoodRepository.DeleteAsync(id);
        if (response.IsSuccess == true) return ResponseBuilder.Success<object>(response.Data!);
        return ResponseBuilder.Failure<object>();
    }

    [HttpPost("add")]
    public async Task<Response<Daily_Food>> Add(Daily_Food model)
    {
        var response =  await Daily_FoodRepository.AddAsync(model);
        if (response.IsSuccess == true) return ResponseBuilder.Success<Daily_Food>(response.Data!);
        return ResponseBuilder.Failure<Daily_Food>();
    }

    [HttpGet("get/{id}")]
    public async Task<Response<Daily_Food>> GetById(Guid id)
    {
        var response = await Daily_FoodRepository.GetByIdAsync(id);
        if (response.IsSuccess == true) return ResponseBuilder.Success<Daily_Food>(response.Data!);
        return ResponseBuilder.Failure<Daily_Food>();
    }

    [HttpPost("update")]
    public async Task<Response<Daily_Food>> Update(Daily_Food model)
    {
        var response =  await Daily_FoodRepository.UpdateAsync(model);
        if (response.IsSuccess == true) return ResponseBuilder.Success<Daily_Food>(response.Data!);
        return ResponseBuilder.Failure<Daily_Food>();
    }
}
