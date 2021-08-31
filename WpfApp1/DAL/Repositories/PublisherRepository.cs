using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.DAL.Repositories
{
    using Entities;
    using MySqlConnector;

    class PublisherRepository
    {
        #region QUERIES
        //private const string ADD_PUBLISHER = "INSERT INTO `publisher`(`name`) VALUES ";
        private const string ALL_PUBLISHERS = "SELECT * FROM publisher";
        #endregion

        #region CRUD methods
        public static List<Publisher> getPublishers()
        {
            List<Publisher> publishers = new List<Publisher>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_PUBLISHERS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    publishers.Add(new Publisher(reader));
                connection.Close();
            }
            return publishers;
        }
        #endregion
    }
}
