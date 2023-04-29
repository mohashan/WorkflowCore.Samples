using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCore.Samples.PassingData.Workflows.AddNumbers.Steps
{
    public class AddNumbersStep : StepBody
    {
        public int Input1 { get; set; }

        public int Input2 { get; set; }

        public int Output { get; set; }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Add Numbers ... ");
            Output = (Input1 + Input2);
            return ExecutionResult.Next();
        }
    }
}
