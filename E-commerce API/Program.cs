using Core.Interface;
using E_commerce_API.Helpers;
using Infrastructure.Data;
using Infrastructure.GenericRepository;
using Infrastructure.ProductRepository;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using E_commerce_API.Middleware;
using Microsoft.AspNetCore.Mvc;
using E_commerce_API.Errors;
using E_commerce_API.Extensions;
using StackExchange.Redis;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Core.Entiies.Identity;

namespace E_commerce_API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
            });
            builder.Services.AddSingleton<IConnectionMultiplexer>(c =>
            {
                
                return ConnectionMultiplexer.Connect("localhost:6379,password=123456,ConnectTimeout=10000");
            });

            builder.Services.AddCors(options => options.AddPolicy(name: "E-commerce.Client", 
                policy =>
                {
                    policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
                })
            );

            builder.Services.AddApplicationServices();
            builder.Services.AddIdentityServices(builder.Configuration);

            var app = builder.Build();

            //apply migration and create database
            using(var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context = services.GetRequiredService<DataContext>();
                    await context.Database.MigrateAsync();
                    await DataContextSeed.SeedAsync(context, loggerFactory);

                    var userManager = services.GetRequiredService<UserManager<AppUser>>();
                    var identityContext = services.GetRequiredService<AppIdentityDbContext>();
                    await identityContext.Database.MigrateAsync();
                    await AppIdentityDbContextSeed.SeedUserAsync(userManager);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occured during migrations");
                }
            }
            

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMiddleware<ExceptionMiddleware>();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStatusCodePagesWithReExecute("/errors/{0}");
            app.UseCors("E-commerce.Client");

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();

            app.MapControllers();

            app.Run();
        }
    }
}