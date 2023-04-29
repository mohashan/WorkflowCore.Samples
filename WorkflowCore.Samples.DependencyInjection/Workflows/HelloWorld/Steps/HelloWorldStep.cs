using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkflowCore.Samples.DependencyInjection.Tools;

namespace WorkflowCore.Samples.DependencyInjection.Workflows.HelloWorld.Steps
{
    public class HelloWorldStep : StepBody
    {
        private readonly IPrinter _printer;

        public HelloWorldStep(IPrinter printer)
        {
            _printer = printer;
        }
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            _printer.Print("Hello World");
            return ExecutionResult.Next();
        }
    }
}
