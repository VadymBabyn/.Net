using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiWebAPI.AppSettings;
using TaxiWebAPI.Model;
using TaxiWebAPI.Repository;
using TaxiWebAPI.DTO;
using Microsoft.Extensions.Caching.Memory;

namespace TaxiWebAPI.Services
{
    public class CarService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly CarRepository _carRepository= new CarRepository(TaxiDataBase.connectionString);
        private readonly DriverRepository _driverRepository = new DriverRepository(TaxiDataBase.connectionString);       
        public CarService()
        {  
        }
        public CarService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }

        public IEnumerable<Car> GetCars()
        {
            string cacheKey = "CarsData";
            if (!_memoryCache.TryGetValue(cacheKey, out IEnumerable<Car>cars))
            {
                cars = _carRepository.GetAllCars();

                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30),
                    SlidingExpiration = TimeSpan.FromMinutes(10)
                };

                _memoryCache.Set(cacheKey, cars, cacheEntryOptions);
            }

            return cars;
        }
        public DriverDTO GetOwnerByCarNumber(string carNumber)
        {
            Driver driver = _driverRepository.GetDriverByNumber(carNumber);

            if (driver != null)
            { 
                return new DriverDTO(driver.Id,driver.FirstName, driver.LastName, driver.Address, driver.PhoneNumber);
            }

            return null; // Повернути null, якщо автомобіль не знайдено
        }
    }
}
