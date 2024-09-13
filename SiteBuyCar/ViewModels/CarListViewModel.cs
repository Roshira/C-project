using WebApplication1.Date.Models;

namespace WebApplication1.ViewModels
{
	public class CarListViewModel
	{
		public IEnumerable<Car> AllCars {  get; set; }
		public string currCategory { get; set; }
	}
}
