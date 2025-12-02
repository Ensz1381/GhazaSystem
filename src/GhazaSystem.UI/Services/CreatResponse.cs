using GhazaSystem.Common.DTOs;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GhazaSystem.UI.Services;

public static class CreatResponse
{
    public static async Task<Response<T>> ToResponse<T>(this HttpResponseMessage responseMessage)
    {
        var responseAsString = await responseMessage.Content.ReadAsStringAsync();
        var responseObject = JsonSerializer.Deserialize<Response<T>>(responseAsString, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            ReferenceHandler = ReferenceHandler.Preserve
        });
        return responseObject;
    } 
}



