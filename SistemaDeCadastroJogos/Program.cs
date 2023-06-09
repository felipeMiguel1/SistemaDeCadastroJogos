using Microsoft.EntityFrameworkCore;
using SistemaDeCadastroJogos.Data;
using SistemaDeCadastroJogos.Repositorios;
using SistemaDeCadastroJogos.Repositorios.Interfaces;

namespace SistemaDeCadastroJogos
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

            builder.Services.AddEntityFrameworkSqlServer().AddDbContext<SistemaJogosDBContex>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));

            builder.Services.AddScoped<IJogoRepositorio, JogoRepositorio>();
            builder.Services.AddScoped<IGeneroRepositorio, GeneroRepositorio>();

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