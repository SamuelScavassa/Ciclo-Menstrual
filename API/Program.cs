using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API;
public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCors();

        // adicionar middlewares (services):
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(option =>
            option.AddPolicy(name: "MyAllowSpecificOrigins",
             builder =>
             {
                 builder
                     .AllowAnyMethod()
                     .AllowAnyHeader()
                     .AllowAnyOrigin();
             }));

        // singleton ou transient

        //string strConn = builder.Configuration.GetConnectionString("Banco");
        //builder.Services.AddDbContext<DBCiclo>(option => option.UseSqlServer(strConn));
        builder.Services.AddDbContext<DBCiclo>(option => option.UseInMemoryDatabase("db")); // Linux não conecta no SQL Server


        WebApplication app = builder.Build();
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseCors("MyAllowSpecificOrigins");
        // usa o middleware (adiciona no pipeline de execução):
        app.MapControllers();
        app.Run();
    }
}