using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCore.Samples.ExternalEvents.Workflows.AddNumbers.Steps
{
    public class DoubleNumbersStep : StepBody
    {
        public int Input { get; set; }

        public int Output { get; set; }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Double Numbers ... ");
            Output = (Input * 2);
            return ExecutionResult.Next();
        }
    }
}
