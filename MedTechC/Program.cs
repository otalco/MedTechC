
using MedTechC.Data;
using MedTechC.Repositories;
using MedTechC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedTechC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<MedTechDbContext>(options =>
            {
                options.UseInMemoryDatabase("Database");
            });

            builder.Services.AddScoped<IPacienteRepositorie, PacienteRepositorie>();

            var app = builder.Build();

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
