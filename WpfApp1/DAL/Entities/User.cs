using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.DAL.Entities
{
    class User
    {
        public sbyte? UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string JoinDate { get; set; }
        public int ReadBooks { get; set; }

        public User(MySqlDataReader reader)
        {
            UserId = sbyte.Parse(reader["user_id"].ToString());
            Login = reader["login"].ToString();
            Password = reader["passwd"].ToString();
            JoinDate = reader["join_date"].ToString();
            ReadBooks = int.Parse(reader["read_books"].ToString());
        }

        public User(User user)
        {
            UserId = user.UserId;
            Login = user.Login;
            Password = user.Password;
            JoinDate = user.JoinDate;
            ReadBooks = user.ReadBooks;
        }

        public override string ToString()
        {
            return $"{Login}";
        }

    }
}
