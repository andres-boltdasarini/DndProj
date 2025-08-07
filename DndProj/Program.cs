using DndProj.Data.Repos;
using FluentValidation.AspNetCore;
using HomeApi.Contracts.Validation;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://dnd-api.blegaming.ru/", "https://dnd-api.blegaming.ru/front/")
        // policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ValidatorAddCharacterRequest>());

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DndApi", Version = "v1" });
});

var app = builder.Build();
app.UseCors(); 
app.UseSwagger();
app.UseSwaggerUI();
app.UseMiddleware<LoggingMiddleware>();
app.MapControllers();
app.Run();
