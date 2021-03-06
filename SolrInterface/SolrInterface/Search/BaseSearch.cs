﻿using System;
using Microsoft.Practices.ServiceLocation;
using SolrInterface.Model;
using SolrInterface.Search.Filter;
using SolrInterface.Search.Sort;
using SolrNet;
using SolrNet.Commands.Parameters;
using SolrNet.Exceptions;
using SolrNet.Impl;

namespace SolrInterface.Search
{
    public abstract class BaseSearch<T> : ISearch<T>
    {
        private readonly ISolrReadOnlyOperations<T> _solr;

        protected BaseSearch()
        {
            var connection = new SolrConnection("http://localhost:8983/solr/test_core");
            Startup.Init<Product>(connection);
            _solr = ServiceLocator.Current.GetInstance<ISolrReadOnlyOperations<T>>();
        }

        public SearchResult<T> Search(SearchParameters parameters)
        {
            int? start = null;
            int? rows = null;

            if (parameters.PageIndex > 0)
            {
                start = (parameters.PageIndex - 1) * parameters.PageSize;
                rows = parameters.PageSize;
            }

            var queryOptions = new QueryOptions
            {
                FilterQueries = FilterBuilder.BuildFilterQueries(parameters),
                Rows = rows,
                Start = start,
                OrderBy = SortBuilder.GetSelectedSort(parameters),
            };

            try
            {
                var matchingResults = _solr.Query(QueryBuilder.BuildQuery(parameters), queryOptions);
                return new SearchResult<T>
                {
                    MatchingResults = matchingResults, 
                    TotalResults = matchingResults.NumFound
                };
            }
            catch (SolrConnectionException exception)
            {
                // log exception and return empty result
                Console.WriteLine($"Url: {exception.Url}    Message: {exception.Message}");
                return new SearchResult<T>();
            }
        }
    }
}
