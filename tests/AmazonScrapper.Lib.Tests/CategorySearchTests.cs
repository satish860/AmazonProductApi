using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AmazonScrapper.Lib.Tests
{
    public class CategorySearchTests
    {
        [Fact]
        public void Should_be_Able_to_Get_Category()
        {
            var category = new CategorySearch();
            var categories = category.GetCategories();
            Assert.NotNull(categories);
        }
    }
}
