using WebApplication1.Date.Models;


namespace WebApplication1.Date.Interfaces
{
    public interface IAllCars
    {

        IEnumerable<Car> Cars { get;}
        IEnumerable<Car> GetFavCars { get;}

        Car getObjectCar(int carId);

    }
}
