using System.Text.Json;
using System.Text.Json.Serialization;

namespace GhazaSystem.blazor.Services;

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
public class Response<T>
{
    public int StatusCode { get; set; }
    public bool IsSuccess { get; set; }
    public List<string>? Errors { get; set; }
    public string? Message { get; set; }

    public T? Data { get; set; }
}


