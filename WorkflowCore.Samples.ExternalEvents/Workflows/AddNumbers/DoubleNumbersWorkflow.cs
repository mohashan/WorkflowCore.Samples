using WorkflowCore.Samples.ExternalEvents.Workflows.AddNumbers.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Samples.ExternalEvents.Workflows.AddNumbers;
using WorkflowCore.Models;

namespace WorkflowCore.Samples.ExternalEvents.Workflows
{
    public class DoubleNumbersWorkflow : IWorkflow<MyDataClass>
    {
        public string Id => nameof(DoubleNumbersWorkflow);

        public int Version =>1;


        public void Build(IWorkflowBuilder<MyDataClass> builder)
        {
            builder
                .StartWith(context=>ExecutionResult.Next())
                .WaitFor("MyEvent",(data,context)=>context.Workflow.Id,data=>DateTime.Now.AddSeconds(5))
                    .Output(data=>data.Value,step=>step.EventData)
                .Then<DoubleNumbersStep>()
                    .Input(step => step.Input, data => data.Value)
                    .Output(data => data.Answer, step => step.Output)
                .Then<PublishMessageStep>()
                    .Input(step => step.Message, data => $"{data.Value} * 2 ==> The Answer is {data.Answer.ToString()}")
                    .Input(step => step.Period, data => TimeSpan.FromSeconds(5))
                .Then(context => Console.WriteLine("workflow complete"));

        }
    }
}
