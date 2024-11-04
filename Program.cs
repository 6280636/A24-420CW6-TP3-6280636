using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using A24_420CW6_TP3_6280636.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<A24_420CW6_TP3_6280636Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("A24_420CW6_TP3_6280636Context") ?? throw new InvalidOperationException("Connection string 'A24_420CW6_TP3_6280636Context' not found.")));

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
