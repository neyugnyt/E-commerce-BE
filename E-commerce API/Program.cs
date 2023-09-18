
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using E_commerce_API.Middleware;
using E_commerce_API.Extensions;
using StackExchange.Redis;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Core.Entiies.Identity;
using Microsoft.Extensions.FileProviders;

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

            //builder.Services.AddDbContext<DataContext>(options =>
            //{
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            //});

            //builder.Services.AddDbContext<AppIdentityDbContext>(options =>
            //{
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
            //});
            builder.Services.AddDbContext<DataContext>(options =>
            {
                var connetionString = builder.Configuration.GetConnectionString("DefaultConnection");
                options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString));
            });

            builder.Services.AddDbContext<AppIdentityDbContext>(options =>
            {
                var connetionString = builder.Configuration.GetConnectionString("IdentityConnection");
                options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString));
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
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "Content")   
                ), RequestPath = "/content"
            });


            app.MapControllers();
            app.MapFallbackToController("Index", "Fallback");
            app.Run();
        }
    }
}