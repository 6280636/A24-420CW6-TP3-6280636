using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using A24_420CW6_TP3_6280636.Data;
using A24_420CW6_TP3_6280636.Models;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<A24_420CW6_TP3_6280636Context>(options =>
{ 
    options.UseSqlServer(builder.Configuration.GetConnectionString("A24_420CW6_TP3_6280636Context") ?? throw new InvalidOperationException("Connection string 'A24_420CW6_TP3_6280636Context' not found."));
    options.UseLazyLoadingProxies();
});

builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<A24_420CW6_TP3_6280636Context>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("Allow all", policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
