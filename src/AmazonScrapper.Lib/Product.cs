using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonScrapper.Lib
{
    public class Product
    {
        public string ProductName { get; set; } = string.Empty;

        public string Asin { get; set; } = String.Empty;

        public Decimal Price { get; set; }

        public Uri? ProductUrl
        {
            get
            {
                return new Uri($"https://www.amazon.in/dp/{Asin}");
            }
        }

        public Uri? ImageUri { get; set; }
    }
}
