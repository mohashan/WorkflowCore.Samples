using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;
using WorkflowCore.Samples.PassingData.Workflows;
using WorkflowCore.Samples.PassingData.Workflows.AddNumbers;
using WorkflowCore.Samples.SharedDependency;

var sharedLibs = new WorkflowSharedLibrary();

var host = sharedLibs.Host();

host.RegisterWorkflow<AddNumbersWorkflow, MyDataClass>();

host.Start();

host.StartWorkflow("AddNumbers");

Console.ReadLine();
host.Stop();

