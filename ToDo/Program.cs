using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using ToDo.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication().AddCookie("auth");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapPost("/signup", (UserDTO user) =>
{
    

    User u = new User 
    { 
        Name = user.Name,
        Username = user.Username,
        Password = user.Password
    };
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();


