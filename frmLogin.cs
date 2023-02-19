using InventoryManagementSystemJV.Database;
using InventoryManagementSystemJV.Models;

namespace InventoryManagementSystemJV
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void cbxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxShowPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            User user = new User(txtNickname.Text, txtPassword.Text);
            DbConnection dbConnection = new DbConnection();
            var isUser = dbConnection.Authentication(user);

            if (isUser != null)
            {
                MessageBox.Show("OK!");
            }
            else
            {
                MessageBox.Show("Name or password is incorrect, try again");
            }
        }
    }
}