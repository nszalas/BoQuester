using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfApp1.DAL.Repositories
{
    using Entities;
    using MySqlConnector;

    class BookAuthorRepository
    {
        #region QUERIES
        private const string ADD_AUTHORSHIP = "INSERT INTO `booksauthors`(`book_id`, `author_id`) VALUES ";
        private const string ALL_AUTHORS = "SELECT * FROM booksauthors";
        #endregion

        public static List<BookAuthor> getAuthorships()
        {
            List<BookAuthor> authorships = new List<BookAuthor>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_AUTHORS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    authorships.Add(new BookAuthor(reader));
                connection.Close();
            }
            return authorships;
        }

        public static bool AddAuthorshipToDataBase(BookAuthor authorShip)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{ADD_AUTHORSHIP} {authorShip.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                state = true;
                authorShip.BooksAuthorsId = (sbyte)command.LastInsertedId;
                connection.Close();
            }
            return state;
        }

        public static bool EditAuthorshipInDataBase(BookAuthor authorship, sbyte authorShipId)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string EDIT_AUTHORSHIP = $"UPDATE booksauthors SET book_id='{authorship.BookId}', author_id='{authorship.AuthorId}', " +
                    $"WHERE id_o={authorShipId}";

                MySqlCommand command = new MySqlCommand(EDIT_AUTHORSHIP, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) state = true;

                connection.Close();
            }
            return state;
        }


    }
}
