using Microsoft.EntityFrameworkCore;
using SuperShopping.OrderAPI.Data;
using SuperShopping.OrderAPI.MessageConsumer;
using SuperShopping.OrderAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<AppDbContext>(builder.Configuration.GetConnectionString("Default"));

var dbContextOptionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
dbContextOptionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
builder.Services.AddSingleton(new OrderRepository(dbContextOptionsBuilder.Options));

builder.Services.AddHostedService<RabbitMQCheckoutConsumer>();

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
