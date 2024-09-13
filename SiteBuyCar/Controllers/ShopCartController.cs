using Microsoft.AspNetCore.Mvc;
using WebApplication1.Date.Interfaces;
using WebApplication1.Date.Models;
using WebApplication1.Date.Repository;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
	public class ShopCartController : Controller
	{
		private readonly IAllCars _carRep;
		private readonly ShopCart _shopCart;

		public ShopCartController(IAllCars carRep, ShopCart shopCart)
		{
			_carRep = carRep;
			_shopCart = shopCart;
		}

		public ViewResult Index()
		{
			var items = _shopCart.getShopItems();
			_shopCart.listShopItems = items;

			var obj = new ShopCartViewModel
			{
				shopCart = _shopCart
			};
			return View(obj);
		}


		public RedirectToActionResult addToCart(int id)
		{
			var item = _carRep.Cars.FirstOrDefault(i => i.Id == id);
			if (item != null)
			{
				_shopCart.AddToCart(item);
			}
			return RedirectToAction("Index");
		}
	}
}
