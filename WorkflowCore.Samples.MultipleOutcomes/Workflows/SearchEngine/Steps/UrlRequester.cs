namespace WorkflowCore.Samples.MultipleOutcomes.Workflows.SearchEngine.Steps
{
    public static class UrlRequester
    {
        public static string sendRequestToSearchEngine(string Url, string text)
        {
            //HttpResponseMessage response;
            string output;
            HttpResponseMessage response = null;

            using (HttpClient http = new HttpClient())
            {
                try
                {
                    response = http.GetAsync($"{Url}/search?q={text}").Result;
                    output = response.Content.ReadAsStringAsync().Result;
                }
                catch (Exception)
                {
                    throw;
                }finally 
                { 
                    response?.Dispose(); 
                }
                

            }
            return output;
        }
    }
}
