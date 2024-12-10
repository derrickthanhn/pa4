//Derrick Nguyen
//UnitTest.cs
//unit tester to check if sqllite works

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SQLite;
using System.IO;

[TestClass]
    public class SQLiteTests
    {
        private const string ConnectionString = "Data Source=:memory:";

        //Tests connection
        [TestMethod]
        public void SQLite_Connection_ShouldOpenSuccessfully()
        {
            // Arrange
            using var connection = new SQLiteConnection(ConnectionString);

            // Act
            connection.Open();

            // Assert
            Assert.AreEqual(System.Data.ConnectionState.Open, connection.State);
        }
        //tests if details are inserted correctly 
        [TestMethod]
        public void SQLite_ShouldInsertOrderDetailsSuccessfully()
        {
            // Arrange
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();

            string createTableQuery = @"
                CREATE TABLE DetailItem (
                    OrderNum INTEGER,
                    DetailNum INTEGER,
                    StockID TEXT,
                    StockName TEXT,
                    StockPrice REAL,
                    Quantity INTEGER
                )";

            using var createCommand = new SQLiteCommand(createTableQuery, connection);
            createCommand.ExecuteNonQuery();

            var detail = new DetailItem
            {
                OrderNumber = 1000,
                DetailNumber = 1,
                StockID = "ELECT001",
                StockName = "42 Inch TV",
                StockPrice = 300.00m,
                Quantity = 1
            };

            // Act
            string insertQuery = @"
                INSERT INTO DetailItem (OrderNum, DetailNum, StockID, StockName, StockPrice, Quantity) 
                VALUES (@OrderNum, @DetailNum, @StockID, @StockName, @StockPrice, @Quantity)";
            using var insertCommand = new SQLiteCommand(insertQuery, connection);

            insertCommand.Parameters.AddWithValue("@OrderNum", detail.OrderNumber);
            insertCommand.Parameters.AddWithValue("@DetailNum", detail.DetailNumber);
            insertCommand.Parameters.AddWithValue("@StockID", detail.StockID);
            insertCommand.Parameters.AddWithValue("@StockName", detail.StockName);
            insertCommand.Parameters.AddWithValue("@StockPrice", detail.StockPrice);
            insertCommand.Parameters.AddWithValue("@Quantity", detail.Quantity);
            int rowsAffected = insertCommand.ExecuteNonQuery();

            // Assert
            Assert.AreEqual(1, rowsAffected);
        }
}