using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolrNet;

namespace SolrInterface.Search.Sort
{
    public class SortBuilder
    {
        public static ICollection<SolrNet.SortOrder> GetSelectedSort(SearchParameters parameters)
        {
            return parameters.SortBy.Select(
                sortBy => sortBy.Order.Equals(SortOrder.Ascending)
                    ? new SolrNet.SortOrder(sortBy.FieldName, Order.ASC)
                    : new SolrNet.SortOrder(sortBy.FieldName, Order.DESC)).ToList();
        }
    }
}
