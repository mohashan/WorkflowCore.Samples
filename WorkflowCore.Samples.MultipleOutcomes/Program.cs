using WorkflowCore.Samples.MultipleOutcomes.Workflows;
using WorkflowCore.Samples.MultipleOutcomes.Workflows.SearchEngine;
using WorkflowCore.Samples.SharedDependency;

var sharedLibs = new WorkflowSharedLibrary();

var host = sharedLibs.Host();

host.RegisterWorkflow<SearchEngineWorkflow,MyDataClass>();

host.Start();
var initialData = new MyDataClass();
var workflowId = host.StartWorkflow(nameof(SearchEngineWorkflow), 1, initialData).Result;

Console.WriteLine("Enter value to select Search Engine :");
Console.WriteLine("1 >> google");
Console.WriteLine("2 >> bing");
Console.WriteLine("3 >> duckduckGo");
Console.WriteLine("other >> yahoo");
Console.WriteLine("0 >> Exit");
string value = Console.ReadLine();

Int32.TryParse(value, out int inputNumber);

while(inputNumber > 0)
    host.PublishEvent("MyEvent", workflowId, inputNumber);

host.Stop();

