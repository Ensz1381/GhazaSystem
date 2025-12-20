using GhazaSystem.Common.Services;
using GhazaSystem.UI.Components;
using GhazaSystem.UI.Interfaces;
using GhazaSystem.UI.Services;
using MudBlazor;
using MudBlazor.Services;

namespace GhazaSystem.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents(options => options.DetailedErrors = true);

            //builder.Services.AddScoped<GhazaSystemCommon>();

            builder.Services.AddMudServices();

            builder.Services.AddScoped<UserServices>();
            builder.Services.AddScoped<FoodServices>();
            builder.Services.AddScoped<LoginServices>();
            builder.Services.AddScoped<FoodChangeServices>();
            builder.Services.AddScoped<DailyFoodServices>();
            builder.Services.AddSingleton<PersianCalendarService>();

            builder.Services.AddHttpClient("api", client =>
            {
                client.BaseAddress = new Uri("http://api:8080/");
            });


            /*
            builder.Services.AddScoped(se => new HttpClient { BaseAddress = new Uri("http://localhost:8080/") });*/
            builder.Services.AddCors(polisy => polisy.AddPolicy("GhazaCorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
                



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors("GhazaCorsPolicy");
            //app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
