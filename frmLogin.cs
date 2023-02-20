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
            if (txtNickname.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Please complete all fields",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtPassword.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Please complete all fields",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            User user = new User(txtNickname.Text, txtPassword.Text);
            DbConnection dbConnection = new DbConnection();
            int idUser = dbConnection.Authentication(user);

            if (idUser != 0)
            {
                this.Hide();
                Form f = new frmMainMenu(idUser);
                f.Closed += (s, args) => this.Close();
                f.Show();
            }
            else
            {
                MessageBox.Show("Name or password is incorrect, try again");
            }
        }
    }
}