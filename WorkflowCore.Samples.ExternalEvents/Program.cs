using WorkflowCore.Samples.ExternalEvents.Workflows;
using WorkflowCore.Samples.ExternalEvents.Workflows.AddNumbers;
using WorkflowCore.Samples.SharedDependency;

var sharedLibs = new WorkflowSharedLibrary();

var host = sharedLibs.Host();

host.RegisterWorkflow<DoubleNumbersWorkflow, MyDataClass>();

host.Start();

var initialData = new MyDataClass();
var workflowId = host.StartWorkflow(nameof(DoubleNumbersWorkflow), 1, initialData).Result;

Console.WriteLine("Enter value to publish");
string value = Console.ReadLine();

Int32.TryParse(value, out int inputNumber);

host.PublishEvent("MyEvent", workflowId, inputNumber);

Console.ReadLine();
host.Stop();

