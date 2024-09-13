using WebApplication1.Date.Interfaces;
using WebApplication1.Date.Models;
using System.Collections.Generic;

namespace WebApplication1.Date.Mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategory
        {


            get
            {
                return new List<Category>
                {
                    new Category { CategoryName = "Electro", desc = "New car" },
                    new Category { CategoryName = "Classic", desc = "Old car" }
                };
            }
        }

    }
}
