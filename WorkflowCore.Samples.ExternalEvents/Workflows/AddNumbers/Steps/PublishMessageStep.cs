using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCore.Samples.ExternalEvents.Workflows.AddNumbers.Steps
{
    public class PublishMessageStep : StepBody
    {
        public TimeSpan Period { get; set; } = TimeSpan.FromSeconds(10);
        public string Message { get; set; }
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            ExecutionResult.Sleep(Period, new object());

            Console.WriteLine($"Here In Last step. Message : {Message}");
            return ExecutionResult.Next();
        }
    }
}
