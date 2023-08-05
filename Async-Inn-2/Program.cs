
using Async_Inn_2.Data;
using Async_Inn_2.Models.Interfaces;
using Async_Inn_2.Models.Services;
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