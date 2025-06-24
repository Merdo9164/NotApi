using NotApi.Application.Interfaces;
using NotApi.Infrastructure.Services;
using FluentValidation.AspNetCore; // FluentValidation için extension metotlar

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddScoped<INotService, NotService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
