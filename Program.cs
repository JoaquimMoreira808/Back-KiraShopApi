using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using KiraApi2;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<KiraApiDbContext>(options =>
    options.UseMySql("server=localhost;user id=root;password=mudar;database=kira2db",
        ServerVersion.AutoDetect("server=localhost;user id=root;password=mudar;database=kira2db")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
