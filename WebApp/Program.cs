
using Invedia.DI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using WebApp.Extensions;
using WebApp.Repository.Infaustructure;


namespace WebApp
{
    public class Program
    {
        //sponor this project @nero-thanh =))
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();
            // Add Identity Service with JWT Token Authentication and Role-based Authorization
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    // Fix Null Reference Exception by checking if configuration is null before accessing GetSection()
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetSection("AppSettings:Token")?.Value ?? throw new Exception("Invalid Token in configuration"))), // Fix possible null reference argument for parameter 's' in 'byte[] Encoding.GetBytes(string s)'.
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            // Add Bb Context
            builder.Services.AddDbContext<AppDbContext>();
            // Add Scoped Dependency Injection with Invedia framework.
            builder.Services.AddDI();
            // Add AutoMapper
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddAutoMapperServices();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(option =>
            {
                option.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                option.OperationFilter<SecurityRequirementsOperationFilter>();
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Orchid v1"));
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();



            app.Run();
        }
    }
}