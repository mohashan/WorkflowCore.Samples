using WorkflowCore.Samples.MultipleOutcomes.Workflows.SearchEngine.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Samples.MultipleOutcomes.Workflows.SearchEngine;
using WorkflowCore.Models;

namespace WorkflowCore.Samples.MultipleOutcomes.Workflows
{
    public class SearchEngineWorkflow : IWorkflow<MyDataClass>
    {
        public string Id => nameof(SearchEngineWorkflow);

        public int Version =>1;

        public void Build(IWorkflowBuilder<MyDataClass> builder)
        {
            builder
                .StartWith(context => ExecutionResult.Next())
                .WaitFor("MyEvent", (data, context) => context.Workflow.Id)
                    .Output(data => data.UserInput, step => step.EventData)

                .Then<SelectSearchEngineStep>(c => c.Name("SelectSearchEngineStep"))
                    .Input(step => step.Input, data => data.UserInput)
                    .Output(data => data.searchEngine, step => step.Output)
                    .Output(data => data.Url, step => step.Url)

                .When(SearchEnginesEnum.google)
                    .Then<GoogleRequestStep>()
                    .Input(step => step.Url, data => data.Url)
                    .Input(step => step.SearchItem, data => data.SearchItem)
                    .Output(data => data.Response, step => step.Output)
                    .End<SelectSearchEngineStep>("SelectSearchEngineStep")

                .When(SearchEnginesEnum.bing)
                    .Then<BingRequestStep>()
                    .Input(step => step.Url, data => data.Url)
                    .Input(step => step.SearchItem, data => data.SearchItem)
                    .Output(data => data.Response, step => step.Output)
                    .End<SelectSearchEngineStep>("SelectSearchEngineStep")

                .When(SearchEnginesEnum.duckduckGo)
                    .Then<DuckDuckGoRequestStep>()
                    .Input(step => step.SearchItem, data => data.SearchItem)
                    .Input(step => step.Url, data => data.Url)
                    .Output(data => data.Response, step => step.Output)
                    .End<SelectSearchEngineStep>("SelectSearchEngineStep")

                .When(SearchEnginesEnum.yahoo)
                    .Then<YahooRequestStep>()
                    .Input(step => step.Url, data => data.Url)
                    .Input(step => step.SearchItem, data => data.SearchItem)
                    .Output(data => data.Response, step => step.Output)
                    .End<SelectSearchEngineStep>("SelectSearchEngineStep")

                .Then<PublishMessageStep>()
                    .Input(step => step.Message, data => data.Response);


        }
    }
}
