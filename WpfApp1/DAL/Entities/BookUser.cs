using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.DAL.Entities
{
    class BookUser
    {
        public sbyte BooksUsersId { get; set; }
        public sbyte UserId { get; set; }
        public sbyte BookId { get; set; }
        public bool IsRead { get; set; }
        public bool WantToRead { get; set; }
        public int Rate { get; set; }

        public BookUser(MySqlDataReader reader)
        {
            BooksUsersId = sbyte.Parse(reader["books_users_id"].ToString());
            UserId = sbyte.Parse(reader["user_id"].ToString());
            BookId = sbyte.Parse(reader["book_id"].ToString());
            IsRead = bool.Parse(reader["is_read"].ToString());
            WantToRead = bool.Parse(reader["want_to_read"].ToString());
            Rate = int.Parse(reader["rate"].ToString());
        }
    }
}
