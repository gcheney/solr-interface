using SolrNet;

namespace SolrInterface.Search
{
    public class SearchResult<T>
    {
        public SolrQueryResults<T> MatchingResults { get; set; }
        public int TotalResults { get; set; }
    }
}
