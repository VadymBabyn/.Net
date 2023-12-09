using TaxiWebAPI.Model;
using TaxiWebAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using TaxiWebAPI.Model;
using TaxiWebAPI.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace TaxiWebAPI.AppSettings
{
    internal class TaxiDataBase
    {

        public static string connectionString = "Server=localhost;Port=3306;Database=taxidb;Uid=root;Pwd=root;";

        // Створення об'єкта MySqlConnection для підключення
        public static void getConnection()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Відкриття підключення до бази даних
                    connection.Open();
                    Console.WriteLine("Connection successful");

                    // Операції з базою даних
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Connection Error: " + ex.Message);
                    throw;
                }
            }                       
        }      
    }
}
