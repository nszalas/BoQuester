using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.DAL.Repositories
{
    using Entities;
    using MySqlConnector;
    class BookUserRepository
    {
        #region QUERIES
        private const string ADD_OWNERSHIP = "INSERT INTO `booksusers`(`user_id`, `book_id`, `is_read`, `want_to_read`, `rate`) VALUES ";
        private const string ALL_OWNERSHIPS = "SELECT * FROM booksusers";
        #endregion

        #region CRUD methods

        public static List<BookUser> getConnections()
        {
            List<BookUser> ownerships = new List<BookUser>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_OWNERSHIPS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    ownerships.Add(new BookUser(reader));
                connection.Close();
            }
            return ownerships;
        }

        public static bool AddOwnershipToDataBase(BookUser ownership)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{ADD_OWNERSHIP} {ownership.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                state = true;
                ownership.BooksUsersId = (sbyte)command.LastInsertedId;
                connection.Close();
            }
            return state;
        }

        public static bool EditBookInDataBase(BookUser ownership, sbyte ownershipId)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string EDIT_OWNERSHIP = $"UPDATE booksusers SET use_id='{ownership.UserId}', book_id='{ownership.BookId}', " +
                    $"is_read={ownership.IsRead}, want_to_read='{ownership.WantToRead}', rate='{ownership.Rate}' WHERE books_users_id={ownershipId}";

                MySqlCommand command = new MySqlCommand(EDIT_OWNERSHIP, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) state = true;

                connection.Close();
            }
            return state;
        }

        #endregion
    }
}
