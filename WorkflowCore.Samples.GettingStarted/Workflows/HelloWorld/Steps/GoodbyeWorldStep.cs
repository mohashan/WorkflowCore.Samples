using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCore.Samples.GettingStarted.Workflows.HelloWorld.Steps
{
    public class GoodbyeWorldStep : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Goodbye World");
            return ExecutionResult.Next();
        }
    }
}
