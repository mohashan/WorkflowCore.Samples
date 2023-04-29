using WorkflowCore.Samples.GettingStarted.Workflows;
using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;
using WorkflowCore.Samples.SharedDependency;

var sharedLibs = new WorkflowSharedLibrary();

var host = sharedLibs.Host();

host.RegisterWorkflow<HelloWorldWorkflow>();

host.Start();

host.StartWorkflow("HelloWorld");
host.StartWorkflow("AddNumbers");

Console.ReadLine();
host.Stop();

