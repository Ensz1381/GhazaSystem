using GhazaSystem.Api.Infrastructure.Data;
using GhazaSystem.Api.Interfaces;
using GhazaSystem.Api.Services;
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
    public async Task<IActionResult> All()
    {
        var logins = await food_changeRepository.GetAllAsync();
        return Ok(logins);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> delete(Guid id)
    {
        await food_changeRepository.DeleteAsync(id);
        return Ok();
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add(Food_Change model)
    {
        await food_changeRepository.AddAsync(model);
        return Ok();
    }

    [HttpGet("get/{id}")]
    public async Task<Food_Change> GetById(Guid id)
    {
        var result = await food_changeRepository.GetByIdAsync(id);
        if (result.Data == null) throw new Exception("is null");
        return result.Data;
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(Food_Change model)
    {
        await food_changeRepository.UpdateAsync(model);
        return Ok();
    }
}
