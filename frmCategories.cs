using InventoryManagementSystemJV.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystemJV
{
    public partial class frmCategories : Form
    {
        public frmCategories()
        {
            InitializeComponent();
        }

        private void frmCategories_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DbConnection dbConnection = new DbConnection();

            dt = dbConnection.CategoryList();

            dgvCategories.DataSource = dt;
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            if (txtCategory.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Please complete the field",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DbConnection dbConnection = new DbConnection();
            bool isOk = dbConnection.CategoryRegistration(txtCategory.Text);

            if (isOk)
            {
                MessageBox.Show("Category successfully registered!");
                txtCategory.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Category registration error, please try again!");
            }
        }
    }
}
