using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using TaxiWebAPI.Model;

namespace TaxiWebAPI.Repository
{
    
    public class CarRepository
    {

        private readonly string _connectionString;

        public CarRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Car> GetAllCars()
        {
            int rowCount = 0;
            string sqlSelect = "SELECT * FROM car";
            string sqlCount = "SELECT COUNT(*) FROM car";
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                // Відкриття підключення
                connection.Open();
                MySqlCommand commandCount = new MySqlCommand(sqlCount, connection);
                
                    // Виконання SQL-запиту та отримання результату (кількість рядків)
                    try
                    {
                        rowCount = Convert.ToInt32(commandCount.ExecuteScalar());                                  
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Count Error: " + ex.Message);
                        throw;
                    }

                Console.WriteLine($"Кількість рядків у таблиці: {rowCount}");
                
                List<Car> cars = new List<Car>();
                

                // Створення об'єкта MySqlCommand для виконання запиту
                using (MySqlCommand command = new MySqlCommand(sqlSelect, connection))
                { 
                    // Виконання SQL-запиту та отримання результатів
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {

                        while(reader.Read())
                        {                        
                            string carNumber = reader.GetString("Number");
                            string carBrand = reader.GetString("Brand");
                            int carYear = reader.GetInt32("Year");
                            string techInspection = reader.GetString("Technical_inspection");
                            string driverId = reader.GetString("passport_id");
                            string carColor = reader.GetString("Color");
                            string carClass = reader.GetString("Car_Class");
                            cars.Add(new Car(carNumber, carBrand, carYear, techInspection, driverId, carColor, carClass));
                        }       
                    }
                }
                return cars;
            }
        }

        public Car GetCarByNumber(string number)
        {
            string sqlSelectByNumber = "SELECT * FROM car WHERE Number = @CarNumber";
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(sqlSelectByNumber, connection))
                {
                    command.Parameters.AddWithValue("@CarNumber", number);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string carNumber = reader.GetString("Number");
                            string carBrand = reader.GetString("Brand");
                            int carYear = reader.GetInt32("Year");
                            string techInspection = reader.GetString("Technical_inspection");
                            string driverId = reader.GetString("passport_id");
                            string carColor = reader.GetString("Color");
                            string carClass = reader.GetString("Car_Class");
                            return new Car(carNumber, carBrand, carYear, techInspection, driverId, carColor, carClass);
                        }
                        return null; // Машина з вказаним номером не знайдена
                    }
                }
            }
        }

        public void AddCar(Car car)
        {
            string sqlInsert = "INSERT INTO car (Number, Brand, Year, Technical_inspection, passport_id, Color, Car_Class) " +
                               "VALUES (@CarNumber, @CarBrand, @CarYear, @TechInspection, @DriverId, @CarColor, @CarClass)";
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(sqlInsert, connection))
                {
                    command.Parameters.AddWithValue("@CarNumber", car.Number);
                    command.Parameters.AddWithValue("@CarBrand", car.Brand);
                    command.Parameters.AddWithValue("@CarYear", car.Year);
                    command.Parameters.AddWithValue("@TechInspection", car.TechnicalInspection);
                    command.Parameters.AddWithValue("@DriverId", car.DriverId);
                    command.Parameters.AddWithValue("@CarColor", car.Color);
                    command.Parameters.AddWithValue("@CarClass", car.CarClass);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateCar(Car car)
        {   
            string sqlUpdate = "UPDATE car SET Brand = @CarBrand, Year = @CarYear, Technical_inspection = @TechInspection, " +
                               "passport_id = @DriverId, Color = @CarColor, Car_Class = @CarClass " +
                               "WHERE Number = @CarNumber";
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(sqlUpdate, connection))
                {
                    command.Parameters.AddWithValue("@CarNumber", car.Number);
                    command.Parameters.AddWithValue("@CarBrand", car.Brand);
                    command.Parameters.AddWithValue("@CarYear", car.Year);
                    command.Parameters.AddWithValue("@TechInspection", car.TechnicalInspection);
                    command.Parameters.AddWithValue("@DriverId", car.DriverId);
                    command.Parameters.AddWithValue("@CarColor", car.Color);
                    command.Parameters.AddWithValue("@CarClass", car.CarClass);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCar(string number)
        {
            string sqlDelete = "DELETE FROM car WHERE Number = @CarNumber";
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(sqlDelete, connection))
                {
                    command.Parameters.AddWithValue("@CarNumber", number);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
