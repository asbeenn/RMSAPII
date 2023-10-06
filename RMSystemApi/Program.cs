using DataLayer;
//using DataLayer.Entities;
using DataLayer.IdentityDbContextModel;
using DataLayer.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
//builder.Services.AddDbContext<RMSDbContext>(options =>
//{
//    options.UseSqlServer(connectionString,
//        b => b.MigrationsAssembly("RMSystemApi"));
//});


var connectionString1 = builder.Configuration.GetConnectionString("DefaultAuthConnectionString");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString1,
        b => b.MigrationsAssembly("RMSystemApi"));
});



builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<IPropertyService, PropertyService>();



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
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
