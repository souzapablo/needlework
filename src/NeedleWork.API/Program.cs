using System.Text.Json.Serialization;
using NeedleWork.API.Middlewares;
using NeedleWork.Application;
using NeedleWork.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opt => 
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
    
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();

IConfiguration configuration = builder.Configuration;
builder.Services.AddInfrastructure(configuration)
    .AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
