using WorkflowCore.Samples.PassingData.Workflows;
using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;
using WorkflowCore.Samples.PassingData.Workflows.AddNumbers;

var serviceProvider = new ServiceCollection()
    .AddLogging()
    .AddWorkflow()
    .BuildServiceProvider();

var host = serviceProvider.GetService<IWorkflowHost>();

if (host == null)
    throw new Exception("Host not initialized");

host.RegisterWorkflow<AddNumbersWorkflow, MyDataClass>();

host.Start();

host.StartWorkflow("AddNumbers");

Console.ReadLine();
host.Stop();

