using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ApiFutebol.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DbJogadoresContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbJogadoresContext") ?? throw new InvalidOperationException("Connection string 'DbJogadoresContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options=>
{
    options.AddPolicy("AllowCrossOrigin", policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();


    });
});


var app = builder.Build();

app.UseCors("AllowCrossOrigin");

using(var scope = app.Services.CreateScope())
{
   var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DbJogadoresContext>();
    context.Database.Migrate();
}

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
