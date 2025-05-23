using Microsoft.EntityFrameworkCore;
using API; 
using System.IO;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .AllowAnyOrigin()   
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=livros.db"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

Console.WriteLine(">>> Diretório atual da API: " + Directory.GetCurrentDirectory());

app.UseCors();

app.MapControllers();

app.Run();
