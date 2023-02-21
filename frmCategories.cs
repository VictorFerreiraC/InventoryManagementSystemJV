using InventoryManagementSystemJV.Database;
using InventoryManagementSystemJV.Models;
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
            LoadDgvCategory();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            if (txtCategory.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Please complete the field",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Category category = new Category(txtCategory.Text);
            DbConnection dbConnection = new DbConnection();

            bool isOk = dbConnection.CategoryRegistration(category);

            if (isOk)
            {
                MessageBox.Show("Category successfully registered!",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCategory.Text = string.Empty;
                LoadDgvCategory();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnEditCategory.Visible = true;
            lblCategoryId.Visible = true;
            lblId.Visible = true;
            btnAddCategory.Visible = false;
            gpbCategory.Text = "Category Editing";

            var row = dgvCategories.SelectedCells[0].RowIndex;

            lblCategoryId.Text = Convert.ToString(dgvCategories.Rows[row].Cells[0].Value.ToString());
            txtCategory.Text = dgvCategories.Rows[row].Cells[1].Value.ToString();
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            if (txtCategory.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Please complete the field",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id = Convert.ToInt32(lblCategoryId.Text);
            string name = txtCategory.Text;
            Category category = new Category(id, name);

            DbConnection dbConnection = new DbConnection();
            bool isOk = dbConnection.CategoryEdit(category);

            if (isOk)
            {
                MessageBox.Show("Category successfully edited!",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCategory.Text = string.Empty;
                btnEditCategory.Visible = false;
                lblCategoryId.Visible = false;
                lblId.Visible = false;
                btnAddCategory.Visible = true;
                gpbCategory.Text = "New Category";
                LoadDgvCategory();
            }
        }

        public void LoadDgvCategory()
        {
            DataTable dt = new DataTable();
            DbConnection dbConnection = new DbConnection();

            dt = dbConnection.CategoryList();

            dgvCategories.DataSource = dt;
        }
    }
}
