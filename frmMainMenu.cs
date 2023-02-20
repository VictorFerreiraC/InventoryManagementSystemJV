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
    public partial class frmMainMenu : Form
    {
        private int idUser;
        private User user;

        public frmMainMenu()
        {
            InitializeComponent();
        }

        public frmMainMenu(int user) : this()
        {
            idUser = user;
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            DbConnection dbConnection = new DbConnection();
            user = dbConnection.UserData(idUser);
            imgUser.ImageLocation = user.Img;
            lblWelcome.Text = "Welcome " + user.Name;
            lblUserType.Text = user.UserTypeName;

        }
    }
}
