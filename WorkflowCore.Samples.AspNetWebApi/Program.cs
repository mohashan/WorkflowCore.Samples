using Microsoft.AspNetCore.Mvc;
using WorkflowCore.Interface;
using WorkflowCore.Samples.SharedDependency;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLogging();
builder.Services.AddWorkflow(x => x.UseSqlServer("Server=.;Database=WorkflowDB;Trusted_Connection=True;TrustServerCertificate=True;",true,true));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/JustForTest", () =>
{
    return new OkResult();
})
.WithName("JustForTest");

var sharedLibs = new WorkflowSharedLibrary();
var serviceCol = sharedLibs.serviceCollection;

var host = sharedLibs.Host(serviceCol);

host.RegisterWorkflow<WorkflowCore.Samples.GettingStarted.Workflows.HelloWorldWorkflow>();

host.Start();

host.StartWorkflow(nameof(WorkflowCore.Samples.GettingStarted.Workflows.HelloWorldWorkflow));

app.Run();


