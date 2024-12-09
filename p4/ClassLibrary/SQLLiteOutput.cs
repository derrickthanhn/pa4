//Derrick Nguyen
//SQLLITE.cs
//Write to SQLLITE Database

using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class SQLIteOutputHandler : OutputHandler
    {
        private readonly string _connectionString;

        /// Constructor to initialize the connection string.
        public SQLIteOutputHandler(string databasePath = "orders.db")
        {
            _connectionString = $"Data Source={databasePath};Version=3;";
        }

        /// Creates a reusable SQLite connection.
        private SQLiteConnection GetConnection()
        {
            var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            return connection;
        }

        /// Writes an order and its details to the database.
        public void WriteOrder(Order order)
        {
            using var connection = GetConnection();
            CreateTablesIfNotExist(connection);

            string orderQuery = @"
                INSERT INTO Orders (OrderNum, OrderTime, CustomerName, CustomerPhone, TaxAmount, TariffAmount, TotalAmount) 
                VALUES (@OrderNum, @OrderTime, @CustomerName, @CustomerPhone, @TaxAmount, @TariffAmount, @TotalAmount)";

            using var orderCommand = new SQLiteCommand(orderQuery, connection);
            orderCommand.Parameters.AddWithValue("@OrderNum", order.OrderNum);
            orderCommand.Parameters.AddWithValue("@OrderTime", order.OrderTime);
            orderCommand.Parameters.AddWithValue("@CustomerName", order.CustomerName);
            orderCommand.Parameters.AddWithValue("@CustomerPhone", order.CustomerPhone);
            orderCommand.Parameters.AddWithValue("@TaxAmount", order.TaxAmount);
            orderCommand.Parameters.AddWithValue("@TariffAmount", order.TariffAmount);
            orderCommand.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);
            orderCommand.ExecuteNonQuery();

            foreach (var detail in order.DetailItems)
            {
                string detailQuery = @"
                    INSERT INTO DetailItem (OrderNum, DetailNum, StockID, StockName, StockPrice, Quantity) 
                    VALUES (@OrderNum, @DetailNum, @StockID, @StockName, @StockPrice, @Quantity)";

                using var detailCommand = new SQLiteCommand(detailQuery, connection);
                detailCommand.Parameters.AddWithValue("@OrderNum", detail.OrderNumber);
                detailCommand.Parameters.AddWithValue("@DetailNum", detail.DetailNumber);
                detailCommand.Parameters.AddWithValue("@StockID", detail.StockID);
                detailCommand.Parameters.AddWithValue("@StockName", detail.StockName);
                detailCommand.Parameters.AddWithValue("@StockPrice", detail.StockPrice);
                detailCommand.Parameters.AddWithValue("@Quantity", detail.Quantity);
                detailCommand.ExecuteNonQuery();
            }
        }

        /// Ensures that necessary tables exist in the database.
        private void CreateTablesIfNotExist(SQLiteConnection connection)
        {
            string createOrdersTable = @"
                CREATE TABLE IF NOT EXISTS Orders (
                    OrderNum INTEGER PRIMARY KEY,
                    OrderTime TEXT NOT NULL,
                    CustomerName TEXT NOT NULL,
                    CustomerPhone TEXT NOT NULL,
                    TaxAmount REAL NOT NULL,
                    TariffAmount REAL NOT NULL,
                    TotalAmount REAL NOT NULL
                )";

            string createOrderDetailsTable = @"
                CREATE TABLE IF NOT EXISTS OrderDetails (
                    DetailID INTEGER PRIMARY KEY AUTOINCREMENT,
                    OrderNum INTEGER NOT NULL,
                    DetailNum INTEGER NOT NULL,
                    StockID TEXT NOT NULL,
                    StockName TEXT NOT NULL,
                    StockPrice REAL NOT NULL,
                    Quantity INTEGER NOT NULL,
                    FOREIGN KEY (OrderNum) REFERENCES Orders(OrderNum)
                )";

            using var createOrdersCommand = new SQLiteCommand(createOrdersTable, connection);
            createOrdersCommand.ExecuteNonQuery();

            using var createOrderDetailsCommand = new SQLiteCommand(createOrderDetailsTable, connection);
            createOrderDetailsCommand.ExecuteNonQuery(); 
        }
}

