using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Samples.DependencyInjection.Workflows.HelloWorld.Steps;

namespace WorkflowCore.Samples.DependencyInjection.Workflows
{
    public class HelloWorldWithDependencyInjectionWorkflow : IWorkflow
    {
        public string Id => nameof(HelloWorldWithDependencyInjectionWorkflow);

        public int Version =>1;

        public void Build(IWorkflowBuilder<object> builder)
        {
            builder
                .StartWith<HelloWorldStep>()
                .Then<GoodbyeWorldStep>();
        }
    }
}
