using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkflowCore.Samples.DependencyInjection.Tools;

namespace WorkflowCore.Samples.DependencyInjection.Workflows.HelloWorld.Steps
{
    public class GoodbyeWorldStep : StepBody
    {
        private readonly IPrinter _printer;

        public GoodbyeWorldStep(IPrinter printer)
        {
            _printer = printer;
        }
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            _printer.Print("Goodbye World");
            return ExecutionResult.Next();
        }
    }
}
