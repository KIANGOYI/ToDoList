using System.Reflection;
using Microsoft.OpenApi.Models;
using NLog;
using ToDoList.WebApi.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSingleton<ILog, Log>(); // Création du singleton de la class Log IPresenceService. IClasseService

builder.Services.AddSwaggerGen(c =>
{
    //Permet de faire la description de la doc
    c.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "Api de To-Do-List",
        Version = "1.0.0",
        Description = "Api pour la gestion des tàches à faire.",
    });
    
    //Inclusion des fichiers xml dans le contexte de l'application en swagger 
    string NomFichier = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    string FichierXml = Path.Combine(AppContext.BaseDirectory, NomFichier);
    c.IncludeXmlComments(FichierXml);
});

var app = builder.Build();

string PathLog = $"{Directory.GetCurrentDirectory()}/bin/Debug/net7.0/NLog.config"; //Création du fichier de configuration pour les logs
LogManager.LoadConfiguration(PathLog); //Chargement du chemin des logs.

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
