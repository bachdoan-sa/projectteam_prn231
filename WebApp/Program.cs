
using Invedia.DI;
using WebApp.Repository.Base.Interface;
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
            builder.Services.AddDbContext<AppDbContext>();
            builder.Services.AddDI();
            
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