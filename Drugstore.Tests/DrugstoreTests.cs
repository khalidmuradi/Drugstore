using System;
using System.Data;
using NUnit.Framework;
using DrugstoreManagement;

namespace DrugstoreManagement.Tests
{
    [TestFixture]
    public class DrugstoreTests
    {
        private DatabaseHelper db;

        [SetUp]
        public void Setup()
        {
            db = new DatabaseHelper();
        }

        [TearDown]
        public void Cleanup()
        {
            db.Dispose();
        }

        [Test]
        public void TestDatabaseConnection()
        {
            string error;
            bool connected = db.TestConnection(out error);
            Assert.IsTrue(connected, "Database connection failed: " + error);
        }

        [Test]
        public void TestMainDashboardQueries()
        {
            using (DatabaseHelper db = new DatabaseHelper())
            {
                string salesQuery = @"
                    SELECT COUNT(*) as SalesCount, Nz(SUM(TotalPrice), 0) as SalesTotal
                    FROM Sales
                    WHERE DateValue(SaleDate) = Date()";

                DataTable salesDt = db.ExecuteQuery(salesQuery);
                Assert.IsNotNull(salesDt);
                Assert.IsTrue(salesDt.Rows.Count > 0);

                string expiryQuery = @"
                    SELECT COUNT(*)
                    FROM Drugs
                    WHERE ExpiryDate BETWEEN Date() AND DateAdd('d', 30, Date())";

                object expiryCount = db.ExecuteScalar(expiryQuery);
                Assert.IsNotNull(expiryCount);
            }
        }

        // Note: UI tests require a UI testing framework and access to internal controls or public setters.
        // This is a placeholder for such tests.
    }
}

