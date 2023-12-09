using TaxiWebAPI.Model;
using MySql.Data.MySqlClient;
using Dapper;

public class ReceiptRepository
{
    private readonly string _connectionString;

    public ReceiptRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IEnumerable<Receipt> GetAllReceipts()
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            string sql = "SELECT * FROM receipt";
            return connection.Query<Receipt>(sql);
        }
    }

    public Receipt GetReceiptById(int receiptNumber)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            string sql = "SELECT * FROM receipt WHERE receipt_number = @ReceiptNumber";
            return connection.QueryFirstOrDefault<Receipt>(sql, new { ReceiptNumber = receiptNumber });
        }
    }

    public void AddReceipt(Receipt receipt)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            string sql = "INSERT INTO receipt (driver_id, pickup_address, destination_address, distance, regular_customer_id, payment_amount, users_passport_serial, open_receipt_date) " +
                         "VALUES (@DriverId, @PickupAddress, @DestinationAddress, @Distance, @RegularCustomerId, @PaymentAmount, @UsersPassportSerial, @OpenReceiptDate)";
            connection.Execute(sql, receipt);
        }
    }

    public void UpdateReceipt(Receipt receipt)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            string sql = "UPDATE receipt SET driver_id = @DriverId, pickup_address = @PickupAddress, destination_address = @DestinationAddress, " +
                         "distance = @Distance, regular_customer_id = @RegularCustomerId, payment_amount = @PaymentAmount, " +
                         "users_passport_serial = @UsersPassportSerial, open_receipt_date = @OpenReceiptDate " +
                         "WHERE receipt_number = @ReceiptNumber";
            connection.Execute(sql, receipt);
        }
    }

    public void DeleteReceipt(int receiptNumber)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            string sql = "DELETE FROM receipt WHERE receipt_number = @ReceiptNumber";
            connection.Execute(sql, new { ReceiptNumber = receiptNumber });
        }
    }
}
