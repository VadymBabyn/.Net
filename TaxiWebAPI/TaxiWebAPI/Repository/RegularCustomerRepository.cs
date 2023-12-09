using Dapper;
using TaxiWebAPI.Model;
using MySql.Data.MySqlClient;

namespace TaxiWebAPI.Repository
{
    public class RegularCustomerRepository
    {
        private readonly string _connectionString;

        public RegularCustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<RegularCustomer> GetRegularCustomersWithReceipts()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT rc.customer_id, rc.first_name, rc.last_name, rc.address, rc.phone_number, " +
              "r.receipt_number, r.pickup_address, r.destination_address, r.distance, r.payment_amount, " +
              "r.users_passport_serial, r.open_receipt_date " +
              "FROM regularcustomer rc " +
              "JOIN receipt r ON rc.customer_id = r.regular_customer_id";

                return connection.Query<RegularCustomer, Receipt, RegularCustomer>(sql,
                    (rc, r) =>
                    {
                        if (rc.Receipts == null)
                            rc.Receipts = new List<Receipt>();
                        rc.Receipts.Add(r);
                        return rc;
                    },
                    splitOn: "receipt_number")
                    .Distinct() // Видаляє дублікати, якщо є більше одного квитка для одного клієнта
                    .ToList();
            }
        }

        public void AddRegularCustomer(RegularCustomer regularCustomer)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO regularcustomer (first_name, last_name, address, phone_number) " +
                             "VALUES (@FirstName, @LastName, @Address, @PhoneNumber)";
                connection.Execute(sql, regularCustomer);

                // Отримуємо ідентифікатор, який було надано автоматично
                int customerId = connection.ExecuteScalar<int>("SELECT LAST_INSERT_ID()");

                // Оновлюємо ідентифікатор у моделі
                regularCustomer.CustomerId = customerId;
            }
        }

        public void AddReceipt(Receipt receipt)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO receipt (customer_id, pickup_address, destination_address, distance, payment_amount, users_passport_serial, open_receipt_date) " +
                             "VALUES (@CustomerId, @PickupAddress, @DestinationAddress, @Distance, @PaymentAmount, @UsersPassportSerial, @OpenReceiptDate)";
                connection.Execute(sql, receipt);
            }
        }

        public void UpdateRegularCustomer(RegularCustomer regularCustomer)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "UPDATE regularcustomer SET first_name = @FirstName, last_name = @LastName, address = @Address, phone_number = @PhoneNumber " +
                             "WHERE customer_id = @CustomerId";
                connection.Execute(sql, regularCustomer);
            }
        }

        public void DeleteRegularCustomer(int customerId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string deleteCustomerSql = "DELETE FROM regularcustomer WHERE customer_id = @CustomerId";
                connection.Execute(deleteCustomerSql, new { CustomerId = customerId });
            }
        }

    }
}
