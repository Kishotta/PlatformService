using Microsoft.EntityFrameworkCore;
using PlatformService.Data;

var builder = WebApplication.CreateBuilder(args);

// TODO: Replace with Sql Server database
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("InMem"));
builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();

builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

PrepareDatabase.PreparePopulation(app);

app.Run();
