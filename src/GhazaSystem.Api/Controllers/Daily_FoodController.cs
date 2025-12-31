using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using GhazaSystem.Api.Interfaces;
using GhazaSystem.Api.Services;
using GhazaSystem.Common.Data;
using GhazaSystem.Common.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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

    [HttpDelete("delete/mont/{mont}")]
    public async Task<Response<object>> deletemont(int mont)
    {
        var AllDaily = await Daily_FoodRepository.GetAllAsync();
        if (AllDaily.IsSuccess == true)
        {
            var listDaily = AllDaily.Data;
            if(listDaily != null)
            {
                foreach (var daily in listDaily)
                {
                    if(daily.Mount ==  mont)
                    {
                        var response = await Daily_FoodRepository.DeleteAsync(daily.Id);
                        
                    }
                }
                return ResponseBuilder.Success();
            }
            

        }
        
        return ResponseBuilder.Failure<object>();
    }

    [HttpPost("add")]
    public async Task<Response<Daily_Food>> Add(Daily_FoodDTOs model)
    {
        Daily_Food DFood = new Daily_Food() { Id = new Guid() , Date = model.Date , food = model.food , Mount = model.Mount };
        var response =  await Daily_FoodRepository.AddAsync(DFood);
        if (response.IsSuccess == true) return ResponseBuilder.Success<Daily_Food>(response.Data!);
        return ResponseBuilder.Failure<Daily_Food>();
    }

    [HttpPost("add/list")]
    public async Task<Response<List<Daily_Food>>> AddList(List<Daily_FoodDTOs> model)
    {
        var ListModel = new List<Daily_Food> ();
        foreach (var item in model)
        {
            Daily_Food DFood = new Daily_Food() { Id = new Guid(), Date = item.Date, foodId = item.food.Id, Mount = item.Mount };
            var response = await Daily_FoodRepository.AddAsync(DFood);
            if (response.IsSuccess == false) return ResponseBuilder.Failure<List<Daily_Food>>();
            ListModel.Add(DFood);
        }
        return ResponseBuilder.Success<List<Daily_Food>>(ListModel);
        
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

    [HttpGet("mont/{number}")]
    public async Task<Response<List<Daily_Food>>> GetMontDailyFood(int number)
    {
        var response = await Daily_FoodRepository.GetAllAsync();
        var data_responce = response.Data;
        var mont_responce = new List<Daily_Food>();
        if (data_responce==null) return ResponseBuilder.Failure<List<Daily_Food>>();
        foreach (var item in data_responce!)
        {
            if(item.Mount==number)
                mont_responce.Add(item);
        }
        if (mont_responce.Count != 0) return ResponseBuilder.Success<List<Daily_Food>>(mont_responce);
        return ResponseBuilder.Failure<List<Daily_Food>>();
    }

    [HttpPost("user")]
    public async Task<Response<List<Daily_Food>>> UserDailyFood(ListUserDailyFoodsDTO model)
    {
        var response = await Daily_FoodRepository.GetListAsync(model);
        if (response.IsSuccess == true) return ResponseBuilder.Success<List<Daily_Food>>(response.Data!);
        return ResponseBuilder.Failure<List<Daily_Food>>(message: "جواب ریپازیوتری نال بود"+response.Message);
    }
}
