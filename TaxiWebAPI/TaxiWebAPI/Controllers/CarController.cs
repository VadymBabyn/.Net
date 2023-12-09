using TaxiWebAPI.Model;
using TaxiWebAPI.Repository;
using TaxiWebAPI.AppSettings;
using Microsoft.AspNetCore.Mvc;
using TaxiWebAPI.Services;
using TaxiWebAPI.DTO;
using Microsoft.Extensions.Caching.Memory;

[Route("api/[controller]")]
[ApiController]
public class CarController : ControllerBase
{
    CarService _carService = new CarService();
    public static IMemoryCache memoryCache = new MemoryCache(new MemoryCacheOptions());
    public CarService carService = new CarService(memoryCache);

    [HttpGet]
    public IEnumerable<Car> GetCars()
    {         
        return carService.GetCars();
    }

    // Отримання інформації про конкретний автомобіль за номером
    [HttpGet("{number}")]
    public IActionResult GetCar(string number)
    {
        try
        {
            CarRepository carRepository = new CarRepository(TaxiDataBase.connectionString);
            Car car = carRepository.GetCarByNumber(number);

            if (car != null)
            {
                return Ok(car); // Повертаємо статус 200 OK та інформацію про автомобіль
            }
            else
            {
                return NotFound($"Автомобіль з номером {number} не знайдений"); // Повертаємо статус 404 Not Found, якщо автомобіль не знайдений
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Помилка: {ex.Message}"); // Повертаємо статус 500 та повідомлення про помилку
        }
    }

    [HttpGet("owner/{carNumber}")]

    public IActionResult GetOwnerByCarNumber(string carNumber)
    {
        try
        {
            DriverDTO owner = _carService.GetOwnerByCarNumber(carNumber);

            if (owner != null)
            {
                return Ok(owner);
            }
            else
            {
                return NotFound($"Власник автомобіля з номером {carNumber} не знайдений");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Помилка: {ex.Message}");
        }
    }
}