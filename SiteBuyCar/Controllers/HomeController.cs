using Microsoft.AspNetCore.Mvc;
using WebApplication1.Date.Interfaces;
using WebApplication1.Date.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        private readonly IAllCars _carRep;
        public HomeController(IAllCars carRep)
        {
            _carRep = carRep;
        }
        public ViewResult Index()
        {
            var homeCars = new HomeViewModel
            {
                favCars = _carRep.GetFavCars
            };

            return View(homeCars);
        }
    }
}
