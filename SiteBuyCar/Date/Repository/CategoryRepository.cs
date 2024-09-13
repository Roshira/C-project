using WebApplication1.Date.Interfaces;
using WebApplication1.Date.Models;

namespace WebApplication1.Date.Repository
{


	public class CategoryRepository : ICarsCategory
	{

		private readonly AppDBContent appDBContent;

		public CategoryRepository(AppDBContent appDBContent)
		{
			this.appDBContent = appDBContent;
		}
		public IEnumerable<Category> AllCategory => appDBContent.Category;
	}
}
