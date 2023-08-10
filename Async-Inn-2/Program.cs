
using Async_Inn_2.Data;
using Async_Inn_2.Models;
using Async_Inn_2.Models.Interfaces;
using Async_Inn_2.Models.Services;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Async_Inn_2

{
    public class Program
{
        public static void Main(string[] args)

        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();


            //Add Services to the container  

            string connString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services
                .AddDbContext<AsyncInnDbContext>
                (opions => opions.UseSqlServer(connString));


            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<AsyncInnDbContext>();

            builder.Services.AddScoped<JwtTokenService>();

            // This will eventually allow us to "Decorate" (Annotate) our routes
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
              .AddJwtBearer(options =>
              {
                  options.TokenValidationParameters = JwtTokenService.GetValidationParameters(builder.Configuration);
              });

            builder.Services.AddAuthorization(options =>
            {
                // Add "Name of Policy", and the Lambda returns a definition
                options.AddPolicy("create", policy => policy.RequireClaim("permissions", "create"));
                options.AddPolicy("update", policy => policy.RequireClaim("permissions", "update"));
                options.AddPolicy("delete", policy => policy.RequireClaim("permissions", "delete"));
                options.AddPolicy("deposit", policy => policy.RequireClaim("permissions", "deposit"));
            });


            builder.Services.AddTransient<IUser, IdentityUserService>();
            builder.Services.AddTransient<IAmenity, AmenityServices>();
            builder.Services.AddTransient<IRoom, RoomServices>();
            builder.Services.AddTransient<IHotel, HotelServices>();
            builder.Services.AddTransient<IHotelRoom, HotelRoomServices>();

            // registers Services

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Async Inn",
                    Version = "v1",
                });
            });


            var app = builder.Build();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger(aptions =>
            {
                aptions.RouteTemplate = "/api/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(aptions =>
            {
                aptions.SwaggerEndpoint("/api/v1/swagger.json", "Async Inn");
                aptions.RoutePrefix = "docs";
            });

            app.MapControllers();

            app.MapGet("/", () => "Hello World!");

            app.Run();


        }
        }
    }