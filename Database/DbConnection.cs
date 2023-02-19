using InventoryManagementSystemJV.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystemJV.Database
{
    internal class DbConnection
    {
        #region Static Objects
        private static SqlConnection sqlConnection = new SqlConnection();
        private static SqlCommand command = new SqlCommand();
        private static string stringConnection = @"Data Source=DESKTOP-MPLKK30\SQLEXPRESS;Initial Catalog=InventoryManagementSystem;Integrated Security=True";
        #endregion

        #region SqlConnection
        public static SqlConnection connection()
        {
            try
            {
                sqlConnection = new SqlConnection(stringConnection);

                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                return sqlConnection;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        #endregion

        #region User authentication
        public User Authentication(User user)
        {
            User isUser = null;
            try
            {
                string sql = "SELECT id_user, name_user, type_user FROM TB_USER WHERE nickname_user = '" + user.Nickname + "' AND password_user = '" + user.Password + "'";
                command.Connection = connection();
                command.CommandText = sql;
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        int type = reader.GetInt32(2);

                        isUser = new User(id, name, type);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
            return isUser;
        }
        #endregion
    }
}
