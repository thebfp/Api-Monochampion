using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Api_One_Trick_Pony_Br;
using Api_One_Trick_Pony_Br.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Api_One_Trick_Pony_BrContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Api_One_Trick_Pony_BrContext") ?? throw new InvalidOperationException("Connection string 'Api_One_Trick_Pony_BrContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.MapPonyEndpoints();

app.MapCommentEndpoints();




app.Run();
