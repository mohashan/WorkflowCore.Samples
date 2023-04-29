using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;
using WorkflowCore.Samples.DependencyInjection.Tools;
using WorkflowCore.Samples.DependencyInjection.Workflows;
using WorkflowCore.Samples.DependencyInjection.Workflows.HelloWorld.Steps;
using WorkflowCore.Samples.SharedDependency;

var sharedLibs = new WorkflowSharedLibrary();
var serviceCol = sharedLibs.serviceCollection;

serviceCol.AddTransient<HelloWorldStep>();
serviceCol.AddTransient<GoodbyeWorldStep>();
serviceCol.AddTransient<IPrinter, ConsoleWriter>();

var host = sharedLibs.Host(serviceCol);

host.RegisterWorkflow<HelloWorldWithDependencyInjectionWorkflow>();

host.Start();

host.StartWorkflow(nameof(HelloWorldWithDependencyInjectionWorkflow));

Console.ReadLine();
host.Stop();

