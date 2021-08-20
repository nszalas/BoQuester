using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.DAL.Entities
{
    class Author
    {
        public sbyte? Author_id { get; set; }
        public string Name { get; set; }
        public string Last_name { get; set; }
        public string Description { get; set; }
        public string Birth_date { get; set; }
        public int Written_books { get; set; }

        public Author(MySqlDataReader reader )
        {
            Author_id = sbyte.Parse(reader["book_id"].ToString());
            Name = reader["name"].ToString();
            Last_name = reader["last_name"].ToString();
            Description = reader["description"].ToString();
            Birth_date = reader["birth_date"].ToString();
            Written_books = int.Parse(reader["written_books"].ToString());
        }
        public Author(string name, string last_name, string description, string birth_date)
        {
            Author_id = null;
            Name = name.Trim();
            Last_name = last_name.Trim();
            Description = description.Trim();
            Birth_date = birth_date.Trim();
            Written_books = 0;
        }

        public Author(Author author)
        {
            Author_id = author.Author_id;
            Name = author.Name;
            Last_name = author.Last_name;
            Description = author.Description;
            Birth_date = author.Birth_date;
            Written_books = author.Written_books;
        }

        public override bool Equals(object obj)
        {
            var author = obj as Author;
            if (author is null) return false;
            if (Name.ToLower() != author.Name.ToLower()) return false;
            if (Last_name.ToLower() != author.Last_name.ToLower()) return false;
            if (Birth_date != author.Birth_date) return false;
            return true;
        }
    }
}
