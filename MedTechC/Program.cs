using MedTechC.Data;
using MedTechC.Repositories;
using MedTechC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Configure DbContext to use SQL Server
        builder.Services.AddDbContext<MedTechDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
        builder.Services.AddScoped<IProntuarioRepository, ProntuarioRepository>();
        builder.Services.AddScoped<ICondutaRepository, CondutaRepository>();

        // Add CORS service
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        // Use CORS middleware
        app.UseCors("AllowAll");

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}