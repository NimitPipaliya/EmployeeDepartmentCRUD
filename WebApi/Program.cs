using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Data.Contract;
using WebApi.Data.Implementations;
using WebApi.Services.Contract;
using WebApi.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(policy =>
{
    policy.AddPolicy("Allow", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContextPool<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("mydb"));
});

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IServices, Services>();
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
app.UseCors("Allow");
app.UseAuthorization();

app.MapControllers();

app.Run();
