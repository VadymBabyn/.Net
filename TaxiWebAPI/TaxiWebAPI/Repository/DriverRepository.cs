using TaxiWebAPI.Model;
using MySql.Data.MySqlClient;
using static TaxiWebAPI.Repository.DriverRepository;

namespace TaxiWebAPI.Repository
{
    public class DriverRepository
    {
        private readonly string _connectionString;
        
        public DriverRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Driver GetDriverByNumber(string number)
        {
            string sqlSelectByNumber = "SELECT * FROM driver WHERE car_number = @CarNumber";
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
                            string first_name = reader.GetString("first_name");
                            string last_name = reader.GetString("last_name");
                            string address = reader.GetString("address");
                            string phone_number = reader.GetString("phone_number");
                            string taxi_service_number = reader.GetString("taxiservice_phone_number");
                            return new Driver(first_name, last_name, address, phone_number, taxi_service_number);
                        }
                        return null; // Driver з вказаним avto не знайденo
                    }
                }
            }
        }

        public IEnumerable<Driver> GetAllDrivers()
        {
            List<Driver> drivers = new List<Driver>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string sqlSelect = "SELECT * FROM Driver";

                using (MySqlCommand command = new MySqlCommand(sqlSelect, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string driverId = reader["id"].ToString();
                            string firstName = reader["first_name"].ToString();
                            string lastName = reader["last_name"].ToString();
                            string address = reader["address"].ToString();
                            string phoneNumber = reader["phone_number"].ToString();
                            string carNumber = reader["car_number"].ToString();
                            string taxiServicePhoneNumber = reader["taxiservice_phone_number"].ToString();

                            drivers.Add(new Driver(driverId, firstName, lastName, address, phoneNumber, carNumber, taxiServicePhoneNumber));
                        }
                    }
                }
            }

            return drivers;
        }

        public void AddDriver(Driver driver)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string sqlInsert = "INSERT INTO Driver (first_name, last_name, address, phone_number, car_number, taxiservice_phone_number) VALUES (@FirstName, @LastName, @Address, @PhoneNumber, @CarNumber, @TaxiServicePhoneNumber)";

                using (MySqlCommand command = new MySqlCommand(sqlInsert, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", driver.FirstName);
                    command.Parameters.AddWithValue("@LastName", driver.LastName);
                    command.Parameters.AddWithValue("@Address", driver.Address);
                    command.Parameters.AddWithValue("@PhoneNumber", driver.PhoneNumber);
                    command.Parameters.AddWithValue("@CarNumber", driver.CarNumber);
                    command.Parameters.AddWithValue("@TaxiServicePhoneNumber", driver.TaxiServicePhoneNumber);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateDriver(Driver driver)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string sqlUpdate = "UPDATE Driver SET first_name = @FirstName, last_name = @LastName, address = @Address, phone_number = @PhoneNumber, car_number = @CarNumber, taxiservice_phone_number = @TaxiServicePhoneNumber WHERE id = @DriverId";

                using (MySqlCommand command = new MySqlCommand(sqlUpdate, connection))
                {
                    command.Parameters.AddWithValue("@DriverId", driver.Id);
                    command.Parameters.AddWithValue("@FirstName", driver.FirstName);
                    command.Parameters.AddWithValue("@LastName", driver.LastName);
                    command.Parameters.AddWithValue("@Address", driver.Address);
                    command.Parameters.AddWithValue("@PhoneNumber", driver.PhoneNumber);
                    command.Parameters.AddWithValue("@CarNumber", driver.CarNumber);
                    command.Parameters.AddWithValue("@TaxiServicePhoneNumber", driver.TaxiServicePhoneNumber);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteDriver(int driverId)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string sqlDelete = "DELETE FROM Driver WHERE id = @DriverId";

                using (MySqlCommand command = new MySqlCommand(sqlDelete, connection))
                {
                    command.Parameters.AddWithValue("@DriverId", driverId);

                    command.ExecuteNonQuery();
                }
            }
        }

    }
}