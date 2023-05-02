using System;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCore.Samples.MultipleOutcomes.Workflows.SearchEngine.Steps
{
    public class SelectSearchEngineStep : StepBody
    {
        public int Input { get; set; }

        public string Url { get; set; }

        public SearchEnginesEnum Output { get; set; }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Base on your number ... ");
            Output = (SearchEnginesEnum)Input;
            Url = Input switch
            {
                1 => "https://google.com",
                2 => "https://bing.com",
                3 => "https://duckduckgo.com",
                _ => "https://yahoo.com"
            };
            return ExecutionResult.Outcome(Output);
        }

        
    }
}
