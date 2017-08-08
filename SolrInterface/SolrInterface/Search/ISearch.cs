using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolrInterface.Search
{
    public interface ISearch<T>
    {
        SearchResult<T> Search(SerachParameters parameters);
    }
}
