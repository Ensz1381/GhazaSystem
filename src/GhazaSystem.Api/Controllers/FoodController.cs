using GhazaSystem.Api.Infrastructure.Data;
using GhazaSystem.Api.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GhazaSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FoodController(
    IInfrasructureRepository<Food> FoodRepository
    ) : ControllerBase
{
    [HttpGet("all")]
    public async Task<IActionResult> All()
    {
        var logins = await FoodRepository.GetAllAsync();
        return Ok(logins);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> delete(Guid id)
    {
        await FoodRepository.DeleteAsync(id);
        return Ok();
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add(Food model)
    {
        await FoodRepository.AddAsync(model);
        return Ok();
    }

    [HttpGet("get/{id}")]
    public async Task<Food> GetById(Guid id)
    {
        var result = await FoodRepository.GetByIdAsync(id);
        if (result.Data == null) throw new Exception("is null");
        return result.Data;
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(Food model)
    {
        await FoodRepository.UpdateAsync(model);
        return Ok();
    }
}