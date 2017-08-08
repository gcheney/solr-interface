using System;
using System.Collections.Generic;
using SolrInterface.Search;
using SolrInterface.Search.Filter;
using SolrInterface.Search.Sort;

namespace SolrInterface
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var searchParameters = new SearchParameters
            {
                FilterBy = new List<FilterQuery>
                {
                    new FilterQuery
                    {
                        FieldName = "title_text",
                        Value = "Great Product 3",
                        DataType = "strings"
                    }
                },
                SortBy = new List<SortQuery>
                {
                    new SortQuery
                    {
                        FieldName = "id",
                        Order = SortOrder.Ascending
                    }
                }
            };

            var productSolrSearch = new ProductSearch();
            var searchResult = productSolrSearch.Search(searchParameters);

            if (searchResult.TotalResults > 0)
            {
                searchResult.MatchingResults
                    .ForEach(result => Console.WriteLine($"{result.Id}:{result.Title}"));
            }
            else
            {
                Console.WriteLine("No search results found.");
            }

            Console.ReadLine();
        }
    }
}
