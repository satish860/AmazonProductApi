using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonScrapper.Lib
{
    public class CategorySearch
    {
        public IList<Category> GetCategories()
        {
            string categoryUrl = "https://www.amazon.in/";
            HtmlWeb document = new HtmlWeb();
            var htmlDocument = document.Load(categoryUrl);
            IList<HtmlNode> htmlNodes = htmlDocument.QuerySelectorAll("#searchDropdownBox option");
            List<Category> categories = new List<Category>();   
            foreach (HtmlNode node in htmlNodes)
            {
                Category category = new Category();
                category.Name = node.InnerText;
                categories.Add(category);
            }
            return categories;
        }
    }
}
