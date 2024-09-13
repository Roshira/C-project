using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using WebApplication1.Date.Interfaces;
using WebApplication1.Date.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class CarController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategory;

        public CarController(IAllCars iallCars, ICarsCategory iCarsCat)
        {
            _allCars = iallCars;
            _allCategory = iCarsCat;
        
                
        }
        [Route("Car/List")]
        [Route("Car/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Car> Cars = null;
            string currCategory = "";

            if (string.IsNullOrEmpty(category))
            {
                Cars = _allCars.Cars.OrderBy(i => i.Id);
            }
            else
            {
                if(string.Equals("Electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    Cars = _allCars.Cars.Where(i => i.Category.CategoryName.Equals("Electro")).OrderBy(i => i.Id);
                }
                else if (string.Equals("Classic", category, StringComparison.OrdinalIgnoreCase))
                {
                    Cars = _allCars.Cars.Where(i => i.Category.CategoryName.Equals("Classic")).OrderBy(i => i.Id);
                }
                currCategory = category;

            }

            var carObj = new CarListViewModel
            {
                AllCars = Cars,
                currCategory = currCategory
            };
            ViewBag.Title = "Page with cars";

            return View(carObj);
        }


    }
}
