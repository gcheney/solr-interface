using System;
using SolrNet.Attributes;

namespace SolrInterface.Model
{
    public class Product
    {
        [SolrUniqueKey("id_text")]
        public string Id { get; set; }

        [SolrField("product_count_integer")]
        public int ProductCount { get; set; }

        [SolrField("title_text")]
        public string Title { get; set; }

        [SolrField("created_on_datetime")]
        public DateTime CreatedOn { get; set; }

        [SolrField("price_decimal")]
        public decimal Price { get; set; }

        [SolrField("inStock_boolean")]
        public bool InStock { get; set; }
    }
}
