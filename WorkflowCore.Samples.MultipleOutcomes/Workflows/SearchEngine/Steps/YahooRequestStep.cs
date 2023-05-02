using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCore.Samples.MultipleOutcomes.Workflows.SearchEngine.Steps
{
    public class YahooRequestStep : StepBody
    {
        public string Url { get; set; }
        public string SearchItem { get; set; }


        public string Output { get; set; }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Sending Request to Yahoo ... ");
            Output = UrlRequester.sendRequestToSearchEngine(Url, SearchItem);
            return ExecutionResult.Next();
        }
    }
}
