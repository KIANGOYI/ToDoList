using System.Reflection;
using Microsoft.OpenApi.Models;
using NLog;
using ToDoList.BusinessLogic.services.business;
using ToDoList.BusinessLogic.services.Interface;
using ToDoList.DataAccess.data;
using ToDoList.WebApi.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
#region Ajout des services provenant du dossier Business
builder.Services.AddSingleton<ILog, Log>(); // Création du singleton de la class Log IPresenceService. IClasseService
builder.Services.AddScoped<ITaskListService, TaskListService>();
#endregion


//Ajout du dbContext de la base de données
builder.Services.AddDbContext<ToDoListDbContext>();
builder.Services.AddSwaggerGen(c =>
{
    //Permet de faire la description de la doc
    c.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "Api de To-Do-List",
        Version = "1.0.0",
        Description = "Api pour la gestion des tàches à faire.",
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(sw => {
        sw.RoutePrefix = string.Empty;
        sw.SwaggerEndpoint("/swagger/v1/swagger.json","api v1");} //Changement du chemin de la documentation
    );
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
