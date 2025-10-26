using GhazaSystem.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection.Emit;

namespace GhazaSystem.Api.Infrastructure;


    public class GhazaDbContext : DbContext
    {
        public DbSet<Food> Food { get; set; }
        public DbSet<Food_Change> Food_Change { get; set; }
        public DbSet<Daily_Food> Daily_Foods { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<User> User { get; set; }



    public GhazaDbContext(DbContextOptions<GhazaDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new FoodConfiguration());
            builder.ApplyConfiguration(new Food_ChangeConfiguration());
            builder.ApplyConfiguration(new Daily_FoodConfiguration());  
            builder.ApplyConfiguration(new LoginConfiguration());
            



         }

    }
    public class GhazaDbContextFactory : IDesignTimeDbContextFactory<GhazaDbContext>
    {

    public GhazaDbContext CreateDbContext(string[] args)
        {
       
            
            //var connectionString = GetConnectionString("DefaultConnection");
            //Console.WriteLine(connectionString);
            var optionsBuilder = new DbContextOptionsBuilder<GhazaDbContext>();
            optionsBuilder.UseNpgsql("Host=db;Port=5432;Database=GhazaSystemDb;Username=admin;Password=secret");
        
            return new GhazaDbContext(optionsBuilder.Options);

        }
    }


