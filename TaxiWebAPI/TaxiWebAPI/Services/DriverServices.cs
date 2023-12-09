using Microsoft.Extensions.Caching.Memory;
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
    public class DriverServices
    {
        private readonly IMemoryCache _memoryCache;
        private readonly CarRepository _carRepository = new CarRepository(TaxiDataBase.connectionString);
        private readonly DriverRepository _driverRepository = new DriverRepository(TaxiDataBase.connectionString);

        public DriverServices(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public IEnumerable<Driver> GetDrivers()
        {
            string cacheKey = "DriversData";

            if (!_memoryCache.TryGetValue(cacheKey, out IEnumerable<Driver> drivers))
            {
                // Дані не знайдено у кеші, отримуємо їх з бази даних
                drivers = _driverRepository.GetAllDrivers();

                // Кешуємо дані на певний час
                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30),
                    SlidingExpiration = TimeSpan.FromMinutes(10)
                };

                _memoryCache.Set(cacheKey, drivers, cacheEntryOptions);
            }

            return drivers;
        }
    }
}
