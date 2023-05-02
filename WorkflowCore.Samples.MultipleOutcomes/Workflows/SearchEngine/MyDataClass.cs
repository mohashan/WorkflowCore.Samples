namespace WorkflowCore.Samples.MultipleOutcomes.Workflows
{
    public class MyDataClass
    {
        public int UserInput { get; set; }
        public SearchEnginesEnum searchEngine { get; set; }
        public string Url { get; set; }
        public string SearchItem { get; set; } = "Search me";
        public string Response { get; set; }
    }
}
