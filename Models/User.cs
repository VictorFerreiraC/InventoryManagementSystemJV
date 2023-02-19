using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystemJV.Models
{
    internal class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Nickname { get; set; }
        public string? Password { get; set; }
        public int TypeUser { get; set; }

        public User()
        {

        }

        //Login
        public User(string nickname, string password)
        {
            this.Nickname = nickname;
            this.Password = password;
        }

        //Current User
        public User(int id, string name, int type)
        {
            this.Id = id;
            this.Name = name;
            this.TypeUser = type;
        }
    }
}
