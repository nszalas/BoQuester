using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.DAL.Repositories
{
    using Entities;
    using MySqlConnector;
    class AuthorRepository
    {
        #region QUERIES
        //private const string ADD_AUTHOR = "INSERT INTO `author`(`name`, `last_name`, `description`, `birth_date`) VALUES ";
        private const string ALL_AUTHORS = "SELECT * FROM booksauthors";
        #endregion

        #region CRUD methods
        public static List<Author> getAuthors()
        {
            List<Author> authors = new List<Author>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_AUTHORS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    authors.Add(new Author(reader));
                connection.Close();
            }
            return authors;
        }


        #endregion

    }
}
