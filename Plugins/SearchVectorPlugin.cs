
using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Microsoft.SemanticKernel;

namespace AgentRGHNTT.Plugins
{
    public class Documents
    {
        public string chunk { get; set; }
        public string title { get; set; }
    }
    public class SearchVectorPlugin
    {
        [KernelFunction("get_search_vector")]
        [EndpointDescription("Get search in database related of NTT DATA about roles and goals. Received param searchQuery for search posibles matchs.")]
        public async Task<List<Documents>> GetSearchVectorAsync(string searchQuery)
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("AZURE_SEARCH_KEY")!);
            SearchIndexClient client = new SearchIndexClient(new Uri(Environment.GetEnvironmentVariable("AZURE_SEARCH_URL")!), credential);
            SearchClient searchClient = client.GetSearchClient(Environment.GetEnvironmentVariable("AZURE_SEARCH_INDEX")!);
            var result = await searchClient.SearchAsync<Documents>(searchQuery, new SearchOptions { Size = 5, IncludeTotalCount = true });
            return result.Value.GetResults().Select(r => r.Document).ToList();
        }
    }
}
