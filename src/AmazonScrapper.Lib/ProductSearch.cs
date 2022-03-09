using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonScrapper.Lib
{
    public class ProductSearch
    {
        public HtmlDocument GetAmazonProduct(string url)
        {
            HtmlWeb document = new HtmlWeb();
            return document.Load(url);
        }

        public string FormUrl(string searchTerm)
        {
            return $"https://www.amazon.in/s?k={Uri.EscapeDataString(searchTerm)}&i=aps";
        }

        public IEnumerable<Product> GetProducts(string searchTerm)
        {
            HtmlDocument htmlDocument = GetAmazonProduct(FormUrl(searchTerm));
            IList<HtmlNode> htmlNodes = htmlDocument.QuerySelectorAll("a > span.a-text-normal");
            return htmlNodes.Select(node => new Product
            {
                ProductName = node.InnerHtml
            });
        }
    }
}
