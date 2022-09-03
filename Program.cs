using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NLog;
using Phantom.API.Common.Helpers;
using Phantom.API.Context;
using Phantom.API.IRepository;
using Phantom.API.IServices;
using Phantom.API.MappingConfiguration;
using Phantom.API.Repository;
using Phantom.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new UserAccessMapping());
});

var mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000", "http://localhost:4200")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PhantomDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddScoped<IBaseResponse<object>, BaseResponse<object>>();
builder.Services.AddScoped<IUserAccessRepository, UserAccessRepository>();
builder.Services.AddScoped<IUserAccessService, UserAccessService>();

//LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config")); // config nlog

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowOrigin");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
