using GhazaSystem.Api.Interfaces;
using GhazaSystem.Api.Services;
using GhazaSystem.Common.Data;
using GhazaSystem.Common.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GhazaSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyController (
    IInfrasructureRepository<Company> CompanyRepository
    ) : ControllerBase
{
    [HttpGet("all")]
    public async Task<Response<List<Company>>> All()
    {
        var com = await CompanyRepository.GetAllAsync();
        if (com == null) return ResponseBuilder.Failure<List<Company>>();

        return ResponseBuilder.Success<List<Company>>(com.Data!);
    }

    [HttpDelete("delete/{id}")]
    public async Task<Response<object>> delete(Guid id)
    {
        await CompanyRepository.DeleteAsync(id);

        return ResponseBuilder.Success(message: "کمپانی با موفقیت پاک شد.");
    }

    [HttpPost("add")]
    public async Task<Response<Company>> Add(CompanyDTOs comdto)
    {
        Company com = new Company()
        {
            Id = new Guid(),
            C_Code = comdto.C_Code!,
            Name = comdto.Name!,
            Users = comdto.Users,
        };

        return await CompanyRepository.AddAsync(com);
    }

    [HttpGet("get/{id}")]
    public async Task<Response<Company>> GetById(Guid id)
    {
        var company = await CompanyRepository.GetByIdAsync(id);
        return ResponseBuilder.Success<Company>(company.Data!);
    }

    [HttpPost("update")]
    public async Task<Response<object>> Update(Company model)
    {
        await CompanyRepository.UpdateAsync(model);
        return ResponseBuilder.Success();
    }



    [HttpGet("code/{code}")]
    public async Task<Response<Company>> GetById(long code)
    {
        var result = await CompanyRepository.GetAllAsync();
        var company = result.Data;

        if (company != null)
        {
            foreach (var com in company)
            {
                if (com.C_Code == code)
                {
                    return ResponseBuilder.Success<Company>(com);
                }
            }
        }
        return ResponseBuilder.Failure<Company>();
    }



}
