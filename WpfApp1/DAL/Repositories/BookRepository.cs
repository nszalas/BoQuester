using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.DAL.Repositories
{
    class BookRepository
    {
        #region QUERIES
        private const string ADD_BOOK = "INSERT INTO `book`(`title`, `release_date`, `publisher`, `category`, `description`, `rate`) VALUES ";
        private const string ALL_BOOKS = "SELECT * FROM book";
        private const string UPDATE_BOOK = "";
        private const string DELETE_BOOK = "DELETE FROM book WHERE book_id=...";
        #endregion

        #region metody CRUD 
        /// <summary>
        /// CRUD - create, read, update, delete
        /// </summary>
        /// <returns></returns>
        #endregion


    }
}
