using System.Linq;
using SolrNet;

namespace SolrInterface.Search
{
    public class QueryBuilder
    {
        public static ISolrQuery BuildQuery(SearchParameters parameters)
        {
            if (!string.IsNullOrEmpty(parameters.FreeSearch))
            {
                return new SolrQuery(parameters.FreeSearch);
            }

            AbstractSolrQuery searchquery = null;

            var solrQuery = parameters.SearchFor
                .Select(searchType => new SolrQuery($"{searchType.Key}:{searchType.Value}"))
                .ToList();

            if (solrQuery.Count > 0)
            {
                searchquery = new SolrMultipleCriteriaQuery(solrQuery, SolrMultipleCriteriaQuery.Operator.OR);
            }

            var solrNotQuery = parameters.Exclude
                .Select(excludeType => new SolrQuery($"{excludeType.Key}:{excludeType.Value}"))
                .ToList();

            if (solrNotQuery.Count > 0)
            {
                searchquery = (searchquery ?? SolrQuery.All) - new SolrMultipleCriteriaQuery(solrNotQuery, SolrMultipleCriteriaQuery.Operator.OR);
            }

            return searchquery ?? SolrQuery.All;
        }
    }
}
