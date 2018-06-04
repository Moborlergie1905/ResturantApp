using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ResturantApp.BOL;
using ResturantApp.Web;
using ResturantApp.Web.Controllers;

namespace ResturantApp.Tests
{
    public class CategoryTests
    {
        [Fact]
        public void CategoriesMethod_ShouldPass()
        {
            CategoryController categoryController = new CategoryController();
            IEnumerable<Category> expected = null;

            IEnumerable<Category> actual = categoryController.Categories();

            Assert.Equal(expected,actual);
        }
    }
}
