using Microsoft.EntityFrameworkCore;
using WebApplication1.Date.Interfaces;
using WebApplication1.Date.Models;

namespace WebApplication1.Date.Repository
{
	public class CarRepository : IAllCars
	{
		private readonly AppDBContent appDBContent;

		public CarRepository(AppDBContent appDBContent)
		{
			this.appDBContent = appDBContent;
		}

		public IEnumerable<Car> Cars => appDBContent.Car.Include(c => c.Category);

		public IEnumerable<Car> GetFavCars => appDBContent.Car.Where(p=> p.isFavorite).Include(c=> c.Category);
		public Car getObjectCar(int carId) => appDBContent.Car.FirstOrDefault(p => p.Id == carId);

	}
}
