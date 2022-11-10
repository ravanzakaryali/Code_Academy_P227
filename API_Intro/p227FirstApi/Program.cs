using Microsoft.EntityFrameworkCore;
using p227FirstApi.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(c => c.AddPolicy("policy", c =>
{
    c.WithOrigins("http://127.0.0.1:5500");
    c.AllowAnyMethod();
    c.AllowAnyHeader();
}));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SQLServer")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("policy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
