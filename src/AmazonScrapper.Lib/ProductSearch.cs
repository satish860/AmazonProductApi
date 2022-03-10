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
            IList<HtmlNode> htmlNodes = htmlDocument.QuerySelectorAll("div[data-component-type=s-search-result]");
            var htmlNode = htmlNodes[0].QuerySelector(".s-image").Attributes["src"].Value;
            IList<Product> products = new List<Product>();
            foreach (HtmlNode node in htmlNodes)
            {
                var product = new Product();
                product.ProductName = node.QuerySelector("a > span.a-text-normal").InnerHtml;
                product.Asin = node.Attributes["data-asin"].Value;
                product.Price = Convert.ToDecimal(node.QuerySelector(".a-price-whole")?.InnerHtml);
                product.ImageUri = new Uri(node.QuerySelector(".s-image").Attributes["src"].Value);
                products.Add(product);
            }
            return products;
        }
    }
}
