using Microsoft.AspNetCore.Mvc;
using WebApplication1.Date;
using WebApplication1.Date.Interfaces;
using WebApplication1.Date.Models;

namespace WebApplication1.Controllers
{
	public class OrderController : Controller
	{
		private readonly IAllOrders allOrders;
		private readonly ShopCart shopCart;

		public OrderController(IAllOrders allOrders, ShopCart shopCart)
		{
			this.allOrders = allOrders; // Правильна ініціалізація залежності
			this.shopCart = shopCart;
		}

		public IActionResult Checkout()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Checkout(Order order)
		{
			shopCart.listShopItems = shopCart.getShopItems();
			Console.WriteLine("Checkout called");

			if (shopCart.listShopItems == null || !shopCart.listShopItems.Any())
			{
				ModelState.AddModelError("", "You must have something in your cart!");
				Console.WriteLine("Validation failed: Cart is empty");
			}

			if (ModelState.IsValid)
			{
				allOrders.createOrder(order);
				Console.WriteLine("Order created");
				return RedirectToAction("Complete");
			}

			Console.WriteLine("Validation failed: ModelState is not valid");
			return View();
		}
		public IActionResult Complete()
		{
			ViewBag.Message = "Order completed successfully!";
			return View();
		}
	}
}

