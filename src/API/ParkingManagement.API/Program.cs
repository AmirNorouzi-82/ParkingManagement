using Microsoft.EntityFrameworkCore;
using ParkingManagement.Persistance.Contexts;
using ParkingManagement.Application.Mappings;
using ParkingManagement.Application.Contracts.Persistance;
using ParkingManagement.Persistance.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext
builder.Services.AddDbContext<ParkingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(VehicleProfile).Assembly);

// Register Repositories & UnitOfWork
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IParkingLogRepository, ParkingLogRepository>();
builder.Services.AddScoped<IParkingSpotRepository, ParkingSpotRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();