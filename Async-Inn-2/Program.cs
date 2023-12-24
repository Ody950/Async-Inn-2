
using JWT_D.Data;
using JWT_D.Models;
using JWT_D.Models.Interfaces;
using JWT_D.Models.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace JWT_D

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
                .AddDbContext<JWTDbContext>
                (opions => opions.UseSqlServer(connString));


            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<JWTDbContext>();

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
            builder.Services.AddTransient<IStock, StockServices>();

            // registers Services

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "JWT_D",
                    Version = "v1",
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "add the JWT TOKEN"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
{{
    new OpenApiSecurityScheme {
    Reference=
    new OpenApiReference{
        Type=ReferenceType.SecurityScheme,
        Id= "Bearer"
}
},
new string[]{ } }
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
                aptions.RoutePrefix = "";
            });

            app.MapControllers();

            app.MapGet("/", () => "Hello World!");

            app.Run();


        }
    }
}