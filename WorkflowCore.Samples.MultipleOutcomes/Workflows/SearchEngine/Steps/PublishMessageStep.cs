﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCore.Samples.MultipleOutcomes.Workflows.SearchEngine.Steps
{
    public class PublishMessageStep : StepBody
    {
        public string Message { get; set; }
        public override ExecutionResult Run(IStepExecutionContext context)
        {

            Console.WriteLine($"Here In Last step. Message : {Message}");
            return ExecutionResult.Next();
        }
    }
}
