using PosVentas.Application.Extensions;
using PosVentas.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);
//hacr el uso de estte servicio 

var Configuration = builder.Configuration;
builder.Services.AddInjectionInfractructure(Configuration);

builder.Services.AddInjeccionApplication(Configuration);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




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
