using HtmlAgilityPack;
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
    }
}
