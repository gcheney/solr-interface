using System.Collections.Generic;
using SolrInterface.Search;
using SolrInterface.Search.Filter;

namespace SolrInterface
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var productSolrSearch = new ProductSearch();
            var searchParameters = new SearchParameters
            {
                FilterBy = new List<FilterQuery>
                {
                    new FilterQuery()
                    {
                        Value = "Product 1",
                        DataType = "String"
                    }
                }
            };

            productSolrSearch.Search(searchParameters);
        }
    }
}
