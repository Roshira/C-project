using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace WebApplication1.Date.Models
{
    public class ShopCart
    {

		private readonly AppDBContent appDBContent;

		public ShopCart(AppDBContent appDBContent)
		{
			this.appDBContent = appDBContent;
		}
		public string ShopCartId { get; set; }

        public List<ShopCartItem> listShopItems { get; set; }

		public static ShopCart GetCart(IServiceProvider services)
		{
			ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
			var context = services.GetService<AppDBContent>();
			string shopCartID = session.GetString("CartId") ?? Guid.NewGuid().ToString();

			session.SetString("CartId", shopCartID);

			return new ShopCart(context) { ShopCartId = shopCartID };
				
		}



		public List<ShopCartItem> getShopItems()
		{
			return appDBContent.shopCartItems.Where(c => c.ShopCartId == ShopCartId).Include(s => s.car).ToList();
		}

		internal void AddToCart(Car car)
		{
			appDBContent.shopCartItems.Add(new ShopCartItem
			{
				ShopCartId = ShopCartId,
				car = car,
				price = car.price
			});
			appDBContent.SaveChanges();
		}
	}
}
