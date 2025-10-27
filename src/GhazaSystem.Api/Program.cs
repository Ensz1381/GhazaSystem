
using GhazaSystem.Api.Infrastructure;
using GhazaSystem.Api.Infrastructure.Data;
using GhazaSystem.Api.Interfaces;
using GhazaSystem.Api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;

namespace GhazaSystem.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<GhazaDbContext>(options =>
               options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            Console.WriteLine(Directory.GetCurrentDirectory());

            builder.Services
            .AddScoped<IInfrasructureRepository<User>, UserRepository>()
            .AddScoped<IInfrasructureRepository<Login>, LoginRepository>()
            .AddScoped<IInfrasructureRepository<Food>, FoodRepository>()
            .AddScoped<IInfrasructureRepository<Food_Change>, Food_ChangeRepository>()
            .AddScoped<IInfrasructureRepository<Daily_Food>, Daily_FoodRepository>();
            

            Console.WriteLine(Directory.GetCurrentDirectory());
            var app = builder.Build();




            var scope = app.Services.CreateScope();
            var serviceProvider = scope.ServiceProvider;
            var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
            var dbContext = serviceProvider.GetRequiredService<GhazaDbContext>();
            try
            {
                Console.WriteLine("... در حال بررسی میگریشن دیتا بیس");

                //dbContext.Database.EnsureDeleted();
                // این متد به صورت خودکار دیتابیس را (اگر وجود نداشته باشد) ایجاد و
                // تمام میگریشن‌های در انتظار را اعمال می‌کند.
                dbContext.Database.Migrate();

                Console.WriteLine("دیتا بیس آپدیت شد");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "مشکلی در میگریشن دیتا بیس وجود دارد");
                // در محیط توسعه، بهتر است برنامه متوقف شود تا خطا دیده شود
                throw;
            }

            var db = scope.ServiceProvider.GetRequiredService<GhazaDbContext>();
            try
            {
                if (db.Database.CanConnect())
                {
                    Console.WriteLine("اتصال به دیتابیس  برقرار شد.");
                }
                else
                {
                    Console.WriteLine("اتصال به دیتابیس  برقرار نشد!"+ db.Database.CanConnect());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("خطا در اتصال به دیتابیس: " + ex.Message);
            }








            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
