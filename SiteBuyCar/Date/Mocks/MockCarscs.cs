using WebApplication1.Date.Interfaces;
using WebApplication1.Date.Models;

namespace WebApplication1.Date.Mocks
{
    public class MockCarscs : IAllCars
    {

        private readonly ICarsCategory _carsCategory = new MockCategory();
        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car> {
                new Car {
                    Name = "Tesla",
                    ShortDesc = "Fast and electro",
                    LongDesc = "Comfortable for live in city",
                    img = "/img/tesla.jpg",
                    price = 40000,
                    isFavorite = true,
                    available = true,
                    Category = _carsCategory.AllCategory.First()
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
                    Category = _carsCategory.AllCategory.Last()
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
                    Category = _carsCategory.AllCategory.Last()
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
                    Category = _carsCategory.AllCategory.Last()
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
                    Category = _carsCategory.AllCategory.Last()
                }


                };


            }
        }
        public IEnumerable<Car> GetFavCars { get; set; }

        public Car getObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
