using Ensek.TechTest.MeterRead.Data.DbContexts;
using Ensek.TechTest.MeterRead.Repositories;
using Ensek.TechTest.MeterRead.Repositories.Interfaces;
using Ensek.TechTest.MeterRead.Services;
using Ensek.TechTest.MeterRead.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("EnsekOrigins",
    builder =>
    {
        builder.WithOrigins("http://example.com", "http://localhost:4200")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MeterReadingContext>((provider, options) =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("MeterReadingConnection"),
        ef => ef.MigrationsAssembly(typeof(MeterReadingContext).Assembly.FullName)));

builder.Services.AddScoped<IUserAccountRepository, UserAccountRepository>();
builder.Services.AddScoped<IMeterReadRepository, MeterReadRepository>();
builder.Services.AddScoped<IFileReadService, CsvFileReadService>();
builder.Services.AddScoped<IMeterReadService, MeterReadService>();
builder.Services.AddScoped<IMeterReadValidatorService, MeterReadValidatorService>();
builder.Services.AddScoped<IUserAccountService, UserAccountService>();

var app = builder.Build();

app.UseCors("EnsekOrigins");

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
