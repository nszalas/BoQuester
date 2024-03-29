﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.DAL.Repositories
{
    using Entities;
    using MySqlConnector;

    class UserRepository
    {

        #region QUERIES
        private const string ALL_USERS = "SELECT * FROM user";
        #endregion

        #region CRUD methods

        public static List<User> getUsers()
        {
            List<User> users = new List<User>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_USERS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    users.Add(new User(reader));
                connection.Close();
            }
            return users;
        } 

        public static User getUser(string username)
        {
            User user = null;
            using (var connection = DBConnection.Instance.Connection)
            {
                string GET_USER = $"SELECT * FROM user WHERE login = '{username}'";
                MySqlCommand command = new MySqlCommand(GET_USER, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    user = new User(reader);
                }
                    
                connection.Close();
            }
            return user;
        }
        
        #endregion
    }
}
