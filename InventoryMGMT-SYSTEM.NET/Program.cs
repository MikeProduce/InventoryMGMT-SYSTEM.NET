using Microsoft.EntityFrameworkCore;
using InventoryMGMT_SYSTEM.NET.Data;
using InventoryMGMT_SYSTEM.NET.Services.UserServices;
using InventoryMGMT_SYSTEM.NET.Repository.UserRepository;

var builder = WebApplication.CreateBuilder(args);
// Example registration in ConfigureServices method
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<InventoryMGMTDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("InventoryMGMTConnectionString")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalHost5173", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();



// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("AllowLocalHost5173");
}



// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
