using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.DAL.Repositories
{
    using Entities;
    using MySqlConnector;

    class BookRepository
    {
        #region QUERIES
        private const string ADD_BOOK = "INSERT INTO `book`(`title`, `release_date`, `publisher`, `category`, `description`, `rate`) VALUES ";
        private const string ALL_BOOKS = "SELECT * FROM book";
        #endregion
        
        #region CRUD methods
        /// <summary>
        /// CRUD - create, read, update, delete
        /// </summary>
        /// <returns></returns>

        public static List<Book> getBooks()
        {
            List<Book> books = new List<Book>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_BOOKS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    books.Add(new Book(reader));
                connection.Close();
            }
            return books;
        }

        public static bool AddBookToDataBase(Book book)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{ADD_BOOK} {book.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                state = true;
                book.Id = (sbyte)command.LastInsertedId;
                connection.Close();
            }
            return state;
        }

        public static bool EditBookInDataBase(Book book, sbyte bookId)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string EDIT_BOOK = $"UPDATE book SET title='{book.Title}', release_date='{book.ReleaseDate}', " +
                    $"publisher={book.Publisher}, category='{book.Category}', description='{book.Description}', rate='{book.Rate}' WHERE book_id={bookId}";

                MySqlCommand command = new MySqlCommand(EDIT_BOOK, connection);
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
