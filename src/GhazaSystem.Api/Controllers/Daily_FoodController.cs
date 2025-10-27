using GhazaSystem.Api.Infrastructure.Data;
using GhazaSystem.Api.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GhazaSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Daily_FoodController(
    IInfrasructureRepository<Daily_Food> Daily_FoodRepository
    ) : ControllerBase
{
    [HttpGet("all")]
    public async Task<IActionResult> All()
    {
        var logins = await Daily_FoodRepository.GetAllAsync();
        return Ok(logins);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> delete(Guid id)
    {
        await Daily_FoodRepository.DeleteAsync(id);
        return Ok();
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add(Daily_Food model)
    {
        await Daily_FoodRepository.AddAsync(model);
        return Ok();
    }

    [HttpGet("get/{id}")]
    public async Task<Daily_Food> GetById(Guid id)
    {
        var result = await Daily_FoodRepository.GetByIdAsync(id);
        if (result.Data == null) throw new Exception("is null");
        return result.Data;
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(Daily_Food model)
    {
        await Daily_FoodRepository.UpdateAsync(model);
        return Ok();
    }
}
