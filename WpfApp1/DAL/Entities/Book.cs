using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.DAL.Entities
{
    class Book
    { 
        public sbyte? Id { get; set; }
        public string Title { get; set; }
        public string ReleaseDate { get; set; }     
        public sbyte Publisher { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Rate { get; set; }

        public Book(MySqlDataReader reader)
        {
            Id = sbyte.Parse(reader["book_id"].ToString());
            Title = reader["title"].ToString();
            ReleaseDate = reader["release_date"].ToString();
            Publisher = sbyte.Parse(reader["publisher"].ToString());
            Category = reader["category"].ToString();
            Description = reader["description"].ToString();
            Rate = double.Parse(reader["rate"].ToString());
        }
        //konstruktor tworzacy obiekt nie dodany jeszcze do bazy z id pustym
        public Book(string title, string releaseDate, sbyte publisher, string category, string description, double rate)
        {
            Id = null;
            Title = title.Trim();
            ReleaseDate = releaseDate.Trim();
            Publisher = publisher;
            Category = category.Trim();
            Description = description.Trim();
            Rate = rate;
        }

        public Book(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            ReleaseDate = book.ReleaseDate;
            Publisher = book.Publisher;
            Category = book.Category;
            Description = book.Description;
            Rate = book.Rate;
          
        }

        public override bool Equals(object obj)
        {
            var book = obj as Book;
            if (book is null) return false;
            if (Title.ToLower() != book.Title.ToLower()) return false;
            if (ReleaseDate.ToLower() != book.ReleaseDate.ToLower()) return false;
            if (Publisher != book.Publisher) return false;
            if (Category.ToLower() != book.Category.ToLower()) return false;
            if (Description.ToLower() != book.Description.ToLower()) return false;
            return true;
        }


    }
}
