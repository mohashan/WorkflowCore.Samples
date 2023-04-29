using WorkflowCore.Samples.GettingStarted.Workflows;
using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;

var serviceProvider = new ServiceCollection()
    .AddLogging()
    .AddWorkflow()
    .BuildServiceProvider();

var host = serviceProvider.GetService<IWorkflowHost>();

if(host == null )
    throw new Exception("Host not initialized");

host.RegisterWorkflow<HelloWorldWorkflow>();

host.Start();

host.StartWorkflow("HelloWorld");

Console.ReadLine();
host.Stop();

