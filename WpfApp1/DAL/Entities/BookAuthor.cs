using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.DAL.Entities
{
    class BookAuthor
    {
        public sbyte? BooksAuthorsId { get; set; }
        public sbyte BookId { get; set; }
        public sbyte AuthorId { get; set; }

        public BookAuthor(MySqlDataReader reader)
        {
            BooksAuthorsId = sbyte.Parse(reader["books_authors_id"].ToString());
            BookId = sbyte.Parse(reader["book_id"].ToString());
            AuthorId = sbyte.Parse(reader["author_id"].ToString());
        }

        public BookAuthor(sbyte bookId, sbyte authorId)
        {
            BooksAuthorsId = null;
            BookId = bookId;
            AuthorId = authorId;
        }

        public BookAuthor(BookAuthor bookAuthor)
        {
            BooksAuthorsId = bookAuthor.BooksAuthorsId;
            BookId = bookAuthor.BookId;
            AuthorId = bookAuthor.AuthorId;
        }

        public string ToInsert()
        {
            return $"('{BookId}', '{AuthorId}')";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var bookAuthor = obj as BookAuthor;
            if (bookAuthor is null) return false;
            if (BookId != bookAuthor.BookId) return false;
            if (AuthorId != bookAuthor.AuthorId) return false;
            return true;
        }
    }
}
