using Comercio.Application.Applications;
using Comercio.Application.Interfaces;
using Comercio.Application.Utils;
using Comercio.Repository.Contexts;
using Comercio.Repository.Repositories.Interfaces;
using Comercio.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IProdutoApplication, ProdutoApplication>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IPedidoApplication, PedidoApplication>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IPedidoProdutoApplication, PedidoProdutoApplication>();
builder.Services.AddScoped<IPedidoProdutoRepository, PedidoProdutoRepository>();
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
    builder => builder.WithOrigins("*")
                      .AllowAnyMethod()
                      .AllowAnyHeader());
});

builder.Services.AddAutoMapper(typeof(Mapping));

builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowSpecificOrigin");
    app.MapOpenApi();
    app.MapSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.MapControllers();
app.Run();

