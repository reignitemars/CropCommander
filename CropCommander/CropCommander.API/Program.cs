using CropCommander.Common;
using CropCommander.Common.DataAccess;
using CropCommander.Common.Handlers.Field;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorWebAssembly", policy =>
    {
        policy.WithOrigins("https://localhost:7206") // Your Blazor WebAssembly URL
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddValidatorsFromAssemblyContaining<AddFieldHandler>();

builder.Services.AddScoped<IDataAccess, FieldDataAccess>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql("Host=localhost;Port=5433;Database=BarnDB;Username=chris;Password=1234");
});
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(MediatRAssemblyEntry).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowBlazorWebAssembly");
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
