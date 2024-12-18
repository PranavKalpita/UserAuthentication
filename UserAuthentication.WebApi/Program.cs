using UserAuthentication.WebApi.DatabaseConfig;
using UserAuthentication.WebApi.Repository;
using UserAuthentication.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register CustomerRepository
builder.Services.AddScoped<UserRepository>();

// Register CustomerService
builder.Services.AddScoped<UserServices>();

// Retrieve the connection string and ensure it's not null
var connectionString = builder.Configuration.GetConnectionString("UserConnection")
    ?? throw new InvalidOperationException("Connection string 'UserConnection' not found.");

// Register DatabaseConfiguration with the connection string
builder.Services.AddScoped<DatabaseConfiguration>(provider =>
    new DatabaseConfiguration(connectionString));

var app = builder.Build();

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
