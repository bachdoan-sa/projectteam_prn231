
using Invedia.DI;
using Repository.Base.Interface;
using Repository.Infaustructure;
using Repository.Repository;
using Repository.Repository.IRepository;
using Service.IServices;
using Service.Services;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddDI();
            builder.Services.AddDbContext<AppDbContext>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Orchid v1"));
            app.UseAuthorization();
            app.MapControllers();
            app.UseAuthorization();

           
            app.Run();
        }
    }
}