using Api;
using Application;
using DataSeeder;
using ErrorHandler.Utills;
using Persistence;
using Queries;


var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddErrorHandler()
    .AddApi()
    .AddApplication()
    .AddQueries()
    .AddInfrastructure();

var app = builder.Build();


if (app.Environment.IsDevelopment())
    new Seeder(app.Services).Start();


app.UseRouting();
app.MapControllers();
app.Run();