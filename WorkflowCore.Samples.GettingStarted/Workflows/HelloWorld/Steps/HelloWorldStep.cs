using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCore.Samples.GettingStarted.Workflows.HelloWorld.Steps
{
    public class HelloWorldStep : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Hello World");
            return ExecutionResult.Next();
        }
    }
}
