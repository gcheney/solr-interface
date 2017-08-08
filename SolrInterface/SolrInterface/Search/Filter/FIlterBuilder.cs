using SolrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolrInterface.Search.Filter
{
    public class FilterBuilder
    {
        public static ICollection<ISolrQuery> BuildFilterQueries(SearchParameters parameters)
        {
           var filter = new List<ISolrQuery>();

            foreach (var filterBy in parameters.FilterBy)
            {
                if (!string.IsNullOrEmpty(filterBy.DataType) && filterBy.DataType.Equals(Constants.DATE_DATATYPE))
                {
                    var upperlim = Convert.ToDateTime(filterBy.UpperLimit);
                    var lowerlim = Convert.ToDateTime(filterBy.LowerLimit);

                    if (upperlim.Equals(lowerlim))
                    {
                        upperlim = upperlim.AddDays(1);
                    }

                    filter.Add(new SolrQueryByRange<DateTime>(filterBy.FieldName, lowerlim, upperlim));
                }
                else
                {
                    if (filterBy.Value.Contains(";"))
                    {
                        var filterValues = filterBy.Value.Split(';');
                        var filterForProduct = filterValues
                            .Select(filterVal => new SolrQueryByField(filterBy.FieldName, filterVal) { Quoted = false })
                            .ToList();

                        filter.Add(new SolrMultipleCriteriaQuery(filterForProduct, SolrMultipleCriteriaQuery.Operator.OR));
                    }
                    else
                    {
                        filter.Add(new SolrQueryByField(filterBy.FieldName, filterBy.Value));
                    }
                }
            }

            return filter;
        }
    }
}
