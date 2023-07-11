using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using RestWhitASP_Net.Model.Context;
using RestWhitASP_Net.Business;
using RestWhitASP_Net.Business.Implamantation;

var builder = WebApplication.CreateBuilder(args);

string MySqlConnection = builder.Configuration.GetConnectionString("MySqlConnection");


builder.Services.AddDbContextPool<MySqlContex>(Options =>
    Options.UseMySql(MySqlConnection, ServerVersion.AutoDetect(MySqlConnection))
);


// Add services to the container.
builder.Services.AddControllers();


builder.Services.AddScoped<IPersonservice, PersonBusinessImplamantation>(); // cada requisi��o � criada uma nova instancia
// builder.Services.AddTransient(); // � instanciado apenas uma vez durante TODA a vida a aplica��o (ex.: conexao com banco de dados)
// builder.Services.AddSingleton(); // � instanciado um vez permanece instanciado durante a vida da sua requisi��o

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

app.Run();

