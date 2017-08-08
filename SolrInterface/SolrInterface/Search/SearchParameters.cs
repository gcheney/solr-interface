using System;
using System.Collections.Generic;
using SolrInterface.Search.Filter;
using SolrInterface.Search.Sort;

namespace SolrInterface.Search
{
    public class SearchParameters
    {
        public const int DefaultPageSize = 5;

        public SearchParameters()
        {
            SearchFor = new Dictionary<string, string>();
            Exclude = new Dictionary<string, string>();
            SortBy = new List<SortQuery>();
            FilterBy = new List<FilterQuery>();
            PageSize = DefaultPageSize;
            PageIndex = 1;
        }

        public SearchParameters(IDictionary<string, string> searchFor = null, 
            IDictionary<string, string> exclude = null, 
            IList<SortQuery> sortBy = null, 
            IList<FilterQuery> filterBy = null, 
            int pageSize = DefaultPageSize, 
            int pageIndex = 1)
        {
            SearchFor = searchFor;
            Exclude = exclude;
            SortBy = sortBy;
            FilterBy = filterBy;
            PageSize = pageSize;
            PageIndex = pageIndex;
        }

        public string FreeSearch { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public IDictionary<string, string> SearchFor { get; set; }
        public IDictionary<string, string> Exclude { get; set; }
        public IList<SortQuery> SortBy { get; set; }
        public IList<FilterQuery> FilterBy { get; set; }
    }
}
