using Microsoft.EntityFrameworkCore;
using Citizen_ReporterAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ReportContext>(opt =>
    opt.UseInMemoryDatabase("ReportList"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFlutterApp",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFlutterApp");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
