using WorkflowCore.Samples.PassingData.Workflows.AddNumbers.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Samples.PassingData.Workflows.AddNumbers;

namespace WorkflowCore.Samples.PassingData.Workflows
{
    public class AddNumbersWorkflow : IWorkflow<MyDataClass>
    {
        public string Id => "AddNumbers";

        public int Version =>1;


        public void Build(IWorkflowBuilder<MyDataClass> builder)
        {
            builder
                .StartWith<AddNumbersStep>()
                    .Input(step => step.Input1, data => data.Value1)
                    .Input(step => step.Input2, data => data.Value2)
                    .Output(data => data.Answer, step => step.Output)
                .Then<PublishMessageStep>()
                    .Input(step => step.Message, data => $"{data.Value1} + {data.Value2} ==> The Answer is {data.Answer.ToString()}");

        }
    }
}
