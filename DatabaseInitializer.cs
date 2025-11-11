using System;
using System.Data.OleDb;
using System.IO;
using System.Runtime.InteropServices;

namespace DrugstoreManagement
{
    public class DatabaseInitializer
    {
        public void InitializeDatabase()
        {
            string dbFile = DatabaseConfig.DatabaseFile;

            if (!File.Exists(dbFile))
            {
                CreateAccessDatabase(dbFile);
                CreateSchema();
            }
            else
            {
                EnsureAdminUser();
            }
        }

        private void CreateAccessDatabase(string path)
        {
            // Ensure directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(path));

            // Use ADOX Catalog to create an .accdb. Requires ACE OLEDB provider and ADOX installed.
            Type catalogType = Type.GetTypeFromProgID("ADOX.Catalog");
            if (catalogType is null)
                throw new InvalidOperationException("ADOX Catalog not available. Install Microsoft Access Database Engine (ACE).");

            dynamic catalog = null;
            try
            {
                catalog = Activator.CreateInstance(catalogType);
                string createConn = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={path};Jet OLEDB:Engine Type=5;";
                // Create method will create the file
                catalog.Create(createConn);
            }
            finally
            {
                if (catalog != null)
                {
                    try { Marshal.FinalReleaseComObject(catalog); }
                    catch { }
                }
            }

            if (!File.Exists(path))
                throw new Exception("Failed to create Access database file.");
        }

        private void CreateSchema()
        {
            using (var helper = new DatabaseHelper())
            {
                // Users Table (Updated with LastLogin and Email)
                string createUsers =
                    "CREATE TABLE Users (" +
                    "[Id] AUTOINCREMENT PRIMARY KEY, " +
                    "[Username] TEXT(100) NOT NULL UNIQUE, " + // Added NOT NULL UNIQUE
                    "[Password] TEXT(256) NOT NULL, " + // Stores hashed password
                    "[PasswordSalt] TEXT(64) NOT NULL, " + // Stores salt for hashing
                    "[FullName] TEXT(100), " +
                    "[Role] TEXT(50), " +
                    "[IsActive] YESNO DEFAULT TRUE, " + // Added DEFAULT TRUE
                    "[IsAdmin] YESNO DEFAULT FALSE, " + // Added DEFAULT FALSE
                    "[LastLogin] DATETIME, " + // Added LastLogin column
                    "[Email] TEXT(255), " + // Added Email column for password reset
                    "[PasswordResetTokenHash] TEXT(256), " + // For password reset functionality
                    "[PasswordResetExpiry] DATETIME" + // For password reset functionality
                    ")";
                helper.ExecuteNonQuery(createUsers);

                // Suppliers Table
                string createSuppliers =
                    "CREATE TABLE Suppliers (" +
                    "[SupplierID] AUTOINCREMENT PRIMARY KEY, " +
                    "[Name] TEXT(255) NOT NULL UNIQUE, " +
                    "[PhoneNo] TEXT(50), " +
                    "[AgentName] TEXT(255), " +
                    "[AgentPhoneNo] TEXT(50), " +
                    "[Address] MEMO" + // MEMO for potentially longer text
                    ")";
                helper.ExecuteNonQuery(createSuppliers);

                // Drugs Table
                string createDrugs =
                    "CREATE TABLE Drugs (" +
                    "[DrugID] AUTOINCREMENT PRIMARY KEY, " +
                    "[Name] TEXT(255) NOT NULL UNIQUE, " +
                    "[Company] TEXT(255), " +
                    "[Dosage] TEXT(100), " +
                    "[Type] TEXT(100), " +
                    "[Barcode] TEXT(100) UNIQUE, " + // Barcode should be unique
                    "[PurchasePrice] CURRENCY NOT NULL, " + // CURRENCY for monetary values
                    "[SellPrice] CURRENCY NOT NULL, " +
                    "[ExpiryDate] DATETIME, " +
                    "[SupplierID] LONG" + // Foreign key to Suppliers
                    ")";
                helper.ExecuteNonQuery(createDrugs);

                // Inventory Table
                string createInventory =
                    "CREATE TABLE Inventory (" +
                    "[InventoryID] AUTOINCREMENT PRIMARY KEY, " +
                    "[DrugID] LONG NOT NULL UNIQUE, " + // One-to-one with Drugs, UNIQUE
                    "[Stock] LONG NOT NULL DEFAULT 0, " + // LONG for integer stock, DEFAULT 0
                    "[StockStatus] TEXT(50)" + // Can be calculated or stored
                    ")";
                helper.ExecuteNonQuery(createInventory);

                // Sales Table
                string createSales =
                    "CREATE TABLE Sales (" +
                    "[SaleID] AUTOINCREMENT PRIMARY KEY, " +
                    "[DrugID] LONG NOT NULL, " +
                    "[Quantity] LONG NOT NULL, " +
                    "[SellPrice] CURRENCY NOT NULL, " +
                    "[DiscountPercent] DOUBLE DEFAULT 0, " + // DOUBLE for percentage
                    "[DiscountAmount] CURRENCY DEFAULT 0, " +
                    "[BorrowAmount] CURRENCY DEFAULT 0, " + // For credit sales
                    "[TotalPrice] CURRENCY NOT NULL, " +
                    "[SaleDate] DATETIME DEFAULT NOW(), " + // DEFAULT NOW() for current date/time
                    "[IsPrescriptionSale] YESNO DEFAULT FALSE, " +
                    "[PrescriptionID] LONG, " + // Link to Prescriptions table
                    "[UserID] LONG" + // Who made the sale
                    ")";
                helper.ExecuteNonQuery(createSales);

                // Purchases Table
                string createPurchases =
                    "CREATE TABLE Purchases (" +
                    "[PurchaseID] AUTOINCREMENT PRIMARY KEY, " +
                    "[DrugID] LONG NOT NULL, " +
                    "[Quantity] LONG NOT NULL, " +
                    "[PurchasePrice] CURRENCY NOT NULL, " +
                    "[PurchaseDate] DATETIME DEFAULT NOW(), " +
                    "[SupplierID] LONG, " +
                    "[UserID] LONG" + // Who made the purchase entry
                    ")";
                helper.ExecuteNonQuery(createPurchases);

                // Prescriptions Table
                string createPrescriptions =
                    "CREATE TABLE Prescriptions (" +
                    "[PrescriptionID] AUTOINCREMENT PRIMARY KEY, " +
                    "[CustomerName] TEXT(255) NOT NULL, " +
                    "[DoctorName] TEXT(255), " +
                    "[PrescriptionDate] DATETIME DEFAULT NOW(), " +
                    "[TotalAmount] CURRENCY NOT NULL, " +
                    "[User ID] LONG" + // Who created the prescription record
                    ")";
                helper.ExecuteNonQuery(createPrescriptions);

                // PrescriptionDetails Table (Junction table for Drugs in a Prescription)
                string createPrescriptionDetails =
                    "CREATE TABLE PrescriptionDetails (" +
                    "[DetailID] AUTOINCREMENT PRIMARY KEY, " +
                    "[PrescriptionID] LONG NOT NULL, " +
                    "[DrugID] LONG NOT NULL, " +
                    "[Quantity] LONG NOT NULL, " +
                    "[SellPrice] CURRENCY NOT NULL, " +
                    "[DiscountPercent] DOUBLE DEFAULT 0, " +
                    "[DiscountAmount] CURRENCY DEFAULT 0, " +
                    "[TotalPrice] CURRENCY NOT NULL" +
                    ")";
                helper.ExecuteNonQuery(createPrescriptionDetails);

                // Now add the foreign key to Sales table for PrescriptionID, as Prescriptions table now exists
                // Note: Access might require this as an ALTER TABLE statement if the table already exists.
                // For initial creation, it's often easier to define it with the table.
                // If the above Sales table creation fails due to this FK, you might need to create Sales without it,
                // then add it with ALTER TABLE. For simplicity here, I'll assume it can be added directly.
                // If not, you'd need: ALTER TABLE Sales ADD CONSTRAINT FK_Sales_Prescriptions FOREIGN KEY (PrescriptionID) REFERENCES Prescriptions(PrescriptionID);

                // StockAdjustments Table (for logging inventory changes)
                string createStockAdjustments =
                    "CREATE TABLE StockAdjustments (" +
                    "[AdjustmentID] AUTOINCREMENT PRIMARY KEY, " +
                    "[DrugID] LONG NOT NULL, " +
                    "[OldQuantity] LONG NOT NULL, " +
                    "[NewQuantity] LONG NOT NULL, " +
                    "[AdjustmentDate] DATETIME DEFAULT NOW(), " +
                    "[Reason] MEMO, " +
                    "[AdjustedBy] LONG" + // User who made the adjustment
                    ")";
                helper.ExecuteNonQuery(createStockAdjustments);

                // Ensure the admin user is created/updated after all tables are ready
                EnsureAdminUser();

                // Add foreign keys using ALTER TABLE for MS Access compatibility
                helper.ExecuteNonQuery("ALTER TABLE Drugs ADD CONSTRAINT FK_Drugs_Supplier FOREIGN KEY ([SupplierID]) REFERENCES Suppliers([SupplierID])");
                helper.ExecuteNonQuery("ALTER TABLE Inventory ADD CONSTRAINT FK_Inventory_Drug FOREIGN KEY ([DrugID]) REFERENCES Drugs([DrugID])");
                helper.ExecuteNonQuery("ALTER TABLE Sales ADD CONSTRAINT FK_Sales_Drug FOREIGN KEY ([DrugID]) REFERENCES Drugs([DrugID])");
                helper.ExecuteNonQuery("ALTER TABLE Sales ADD CONSTRAINT FK_Sales_User FOREIGN KEY ([User ID]) REFERENCES Users([Id])");
                helper.ExecuteNonQuery("ALTER TABLE Purchases ADD CONSTRAINT FK_Purchases_Drug FOREIGN KEY ([DrugID]) REFERENCES Drugs([DrugID])");
                helper.ExecuteNonQuery("ALTER TABLE Purchases ADD CONSTRAINT FK_Purchases_Supplier FOREIGN KEY ([SupplierID]) REFERENCES Suppliers([SupplierID])");
                helper.ExecuteNonQuery("ALTER TABLE Purchases ADD CONSTRAINT FK_Purchases_User FOREIGN KEY ([User ID]) REFERENCES Users([Id])");
                helper.ExecuteNonQuery("ALTER TABLE Prescriptions ADD CONSTRAINT FK_Prescriptions_User FOREIGN KEY ([User ID]) REFERENCES Users([Id])");
                helper.ExecuteNonQuery("ALTER TABLE PrescriptionDetails ADD CONSTRAINT FK_PrescriptionDetails_Prescription FOREIGN KEY ([PrescriptionID]) REFERENCES Prescriptions([PrescriptionID])");
                helper.ExecuteNonQuery("ALTER TABLE PrescriptionDetails ADD CONSTRAINT FK_PrescriptionDetails_Drug FOREIGN KEY ([DrugID]) REFERENCES Drugs([DrugID])");
                helper.ExecuteNonQuery("ALTER TABLE StockAdjustments ADD CONSTRAINT FK_StockAdjustments_Drug FOREIGN KEY ([DrugID]) REFERENCES Drugs([DrugID])");
                helper.ExecuteNonQuery("ALTER TABLE StockAdjustments ADD CONSTRAINT FK_StockAdjustments_User FOREIGN KEY ([AdjustedBy]) REFERENCES Users([Id])");

            }
        }

        private void EnsureAdminUser()
        {
            const string defaultUsername = "khalidmuradi";
            const string defaultPassword = "Masom@1994";
            using (var helper = new DatabaseHelper())
            {
                string checkQuery = "SELECT COUNT(*) FROM Users WHERE [Username] = ?";
                OleDbParameter[] checkParams = { new OleDbParameter("Username", defaultUsername) };
                object result = helper.ExecuteScalar(checkQuery, checkParams);
                int count = result != null ? Convert.ToInt32(result) : 0;
                string salt = PasswordHelper.GenerateSalt();
                string hash = PasswordHelper.HashPassword(defaultPassword, salt);
                if (count == 0)
                {
                    string insert = "INSERT INTO Users ([Username], [Password], [PasswordSalt], [FullName], [Role], [IsActive], [IsAdmin], [Email]) VALUES (?, ?, ?, ?, ?, ?, ?, ?)";
                    OleDbParameter[] insertParams = {
                        new OleDbParameter("Username", defaultUsername),
                        new OleDbParameter("Password", hash),
                        new OleDbParameter("PasswordSalt", salt),
                        new OleDbParameter("FullName", "Administrator"),
                        new OleDbParameter("Role", "Admin"),
                        new OleDbParameter("IsActive", true),
                        new OleDbParameter("IsAdmin", true),
                        new OleDbParameter("Email", "admin@example.com") // Default email for admin
                    };
                    helper.ExecuteNonQuery(insert, insertParams);
                }
                else
                {
                    // Update password, salt, and potentially other fields for existing admin
                    string update = "UPDATE Users SET [Password] = ?, [PasswordSalt] = ?, [FullName] = ?, [Role] = ?, [IsActive] = ?, [IsAdmin] = ? WHERE [Username] = ?";
                    OleDbParameter[] updateParams = {
                        new OleDbParameter("Password", hash),
                        new OleDbParameter("PasswordSalt", salt),
                        new OleDbParameter("FullName", "Administrator"),
                        new OleDbParameter("Role", "Admin"),
                        new OleDbParameter("IsActive", true),
                        new OleDbParameter("IsAdmin", true),
                        new OleDbParameter("Username", defaultUsername)
                    };
                    helper.ExecuteNonQuery(update, updateParams);
                }
            }
        }
    }
}
