using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AmazonScrapper.Lib.Tests
{
    public class ProductSearchTests
    {
        [Fact]
        public void GetProductBySearchForDefaultCountry()
        { 
            ProductSearch searchProduct = new ProductSearch();
            var amazonproducts = searchProduct.GetAmazonProduct("https://www.amazon.in/s?k=Xbox%20one&i=aps");
            Assert.NotNull(amazonproducts);
        }

        [Fact]
        public void FormUrlUsingThesearchTerm()
        {
            var searchProduct = new ProductSearch();
            Assert.Equal("https://www.amazon.in/s?k=Xbox%20one&i=aps", searchProduct.FormUrl("Xbox one"));
        }
    }
}
