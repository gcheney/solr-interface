using SolrInterface.Search;

namespace SolrInterface
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var search = new ProductSearch();
            search.Search(new SearchParameters());
        }
    }
}
