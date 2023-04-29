using WorkflowCore.Samples.GettingStarted.Workflows.HelloWorld.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;

namespace WorkflowCore.Samples.GettingStarted.Workflows
{
    public class HelloWorldWorkflow : IWorkflow
    {
        public string Id => "HelloWorld";

        public int Version =>1;

        public void Build(IWorkflowBuilder<object> builder)
        {
            builder
                .StartWith<HelloWorldStep>()
                .Then<GoodbyeWorldStep>();
        }
    }
}
