using WebApplication1.Date.Interfaces;
using WebApplication1.Date.Models;
using System.Linq;


namespace WebApplication1.Date
{
	public class DBObject
	{
		public static void Initial(AppDBContent content)
		{


			if (!content.Category.Any())
			{
				content.Category.AddRange(Categories.Select(c => c.Value));
			}

			if (!content.Car.Any())
			{
				content.AddRange(
					 new Car
					 {
						 Name = "Tesla",
						 ShortDesc = "Fast and electro",
						 LongDesc = "Comfortable for live in city",
						 img = "/img/tesla.jpg",
						 price = 40000,
						 isFavorite = true,
						 available = true,
						 Category = Categories["Electro"]
					 },

				new Car
				{
					Name = "FordTransporter",
					ShortDesc = "Good for transporter parcel",
					LongDesc = "Comfortable for work",
					img = "/img/transporter.jpg",
					price = 30000,
					isFavorite = true,
					available = true,
					Category = Categories["Classic"]
				},
				 new Car
				 {
					 Name = "ЗАЗ Славута",
					 ShortDesc = "Econonom",
					 LongDesc = "Comfortable for live in city",
					 img = "/img/Slavuta.jpg",
					 price = 2000,
					 isFavorite = false,
					 available = true,
					 Category = Categories["Classic"]
				 },
				  new Car
				  {
					  Name = "Porch Panamera",
					  ShortDesc = "Fast and elite",
					  LongDesc = "For fast drive",
					  img = "/img/panamera.jpg",
					  price = 65000,
					  isFavorite = true,
					  available = true,
					  Category = Categories["Classic"]
				  },
				   new Car
				   {
					   Name = "Golf",
					   ShortDesc = "Mini and econom",
					   LongDesc = "Comfortable for live in city",
					   img = "/img/golf.jpg",
					   price = 12000,
					   isFavorite = false,
					   available = true,
					   Category = Categories["Classic"]
				   }
					);
				
			}
			content.SaveChanges();

		}

		private static Dictionary<string, Category> category;
		public static Dictionary<string, Category> Categories
		{
			get
			{
				if (category == null)
				{
					var list = new Category[]
					{
						new Category { CategoryName = "Electro", desc = "New category car" },
						new Category { CategoryName = "Classic", desc = "no new car" }
					};

					category = new Dictionary<string, Category>();
					foreach (Category el in list)
						category.Add(el.CategoryName, el);
				}
				return category;
			}
		}
	}
}
