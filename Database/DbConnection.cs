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
        public int Authentication(User user)
        {
            int isUser = 0;
            try
            {
                string sql = "SELECT id_user FROM TB_USER WHERE nickname_user = '" + user.Nickname + "' AND password_user = '" + user.Password + "'";
                command.Connection = connection();
                command.CommandText = sql;
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        isUser = reader.GetInt32(0);
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

        #region User data
        public User UserData(int idUser)
        {
            int id = 0;
            string name = null;
            int type = 0;
            string typeName = null;
            string img = null;
            try
            {
                string sql = "SELECT TB_USER.id_user, TB_USER.name_user, TB_USER.type_user, TB_USER_TYPE.name_userType, TB_USER.img_user FROM TB_USER INNER JOIN TB_USER_TYPE ON TB_USER.type_user = TB_USER_TYPE.id_userType WHERE id_user = " + idUser;
                command.Connection = connection();
                command.CommandText = sql;
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = reader.GetInt32(0);
                        name = reader.GetString(1);
                        type = reader.GetInt32(2);
                        typeName = reader.GetString(3);
                        img = reader.GetString(4);
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
            User user = new User(id, name, type, typeName, img);
            return user;
        }
        #endregion

        #region category list
        public DataTable CategoryList()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Name");

            try
            {
                string sql = "SELECT * FROM TB_CATEGORY";
                command.Connection = connection();
                command.CommandText = sql;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    dt.Rows.Add(reader.GetInt32(0),reader.GetString(1));
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
            return dt;
        }
        #endregion

        #region Category registration
        public bool CategoryRegistration(string categoryName)
        {
            bool isOk = false;
            try
            {
                string sql = "INSERT INTO TB_CATEGORY(name_category) VALUES ('" + categoryName + "')";
                command.Connection = connection();
                command.CommandText = sql;
                command.ExecuteNonQuery();
                isOk = true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }

            return isOk;
        }
        #endregion
    }
}
