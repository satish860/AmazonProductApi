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
        private readonly IEnumerable<Product> _products;    
        public ProductSearchTests()
        {
            ProductSearch productSearch = new ProductSearch();
            _products = productSearch.GetProducts("Xbox one");
            Console.WriteLine(_products.Count());
        }

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

        [Fact]
        public void Should_be_Able_to_Get_Product_From_Html()
        {
            Assert.True(_products.Any());
        }

        [Fact]
        public void Should_be_Able_to_ASIN()
        {
            Assert.NotEmpty(_products.First().Asin);
        }

        [Fact]
        public void Should_be_Able_to_Get_Products()
        {
            Assert.NotEqual(0,_products.First().Price);
        }

        [Fact]
        public void Should_be_Able_to_Get_Url()
        {
            var asin = _products.First().Asin;
            Assert.Equal( new Uri($"https://www.amazon.in/dp/{asin}"), _products.First().ProductUrl);
        }

        [Fact]
        public void Should_be_Able_to_Get_Image_Url()
        {
            Assert.NotNull(_products.First().ImageUri);
        }
    }
}
