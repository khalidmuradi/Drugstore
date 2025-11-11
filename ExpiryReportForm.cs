using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrugstoreManagement
{
    public partial class ExpiryReportForm : Form
    {
        public ExpiryReportForm()
        {
            InitializeComponent();
            LoadExpiryData();
        }

        private void LoadExpiryData()
        {
            DatabaseHelper db = new DatabaseHelper();
            string query = @"
                SELECT 
                    d.Name,
                    d.Company,
                    d.ExpiryDate,
                    i.Stock,
                    CASE 
                        WHEN d.ExpiryDate <= GETDATE() THEN 'Expired'
                        WHEN d.ExpiryDate <= DATEADD(day, 30, GETDATE()) THEN 'Expiring Soon'
                        ELSE 'Normal'
                    END as Status,
                    DATEDIFF(day, GETDATE(), d.ExpiryDate) as DaysUntilExpiry
                FROM Drugs d
                INNER JOIN Inventory i ON d.DrugID = i.DrugID
                WHERE d.ExpiryDate <= DATEADD(day, 90, GETDATE())
                ORDER BY d.ExpiryDate";

            DataTable dt = db.ExecuteQuery(query);
            dataGridViewExpiry.DataSource = dt;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}