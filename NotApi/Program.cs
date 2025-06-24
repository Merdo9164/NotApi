using NotApi.Application.Interfaces;
using NotApi.Infrastructure.Services;
using FluentValidation.AspNetCore; // FluentValidation için extension metotlar
using NotApi.Infrastructure.Contexts; // DbContext'i tanımak için
using Microsoft.EntityFrameworkCore; // UseSqlServer için

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NotDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
