using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    using DAL.Entities;
    using DAL.Repositories;
    using System.Collections.ObjectModel;
    using System.Diagnostics;

    class Model
    {
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();
        public ObservableCollection<Book> Ksiazki { get; set; } = new ObservableCollection<Book>();
        public static ObservableCollection<Book> DoPrzeczytania { get; set; } = new ObservableCollection<Book>();
        public static ObservableCollection<Book> Przeczytane { get; set; } = new ObservableCollection<Book>();

        public ObservableCollection<Book> Znalezione { get; set; } = new ObservableCollection<Book>();
      

        // get data from database to collection
        public Model()
        {
            var users = UserRepository.getUsers();
            foreach (var user in users)
                Users.Add(user);
            var ksiazki = BookRepository.getBooks();
            foreach (var book in ksiazki)
                Ksiazki.Add(book);
            
            
        }

       
        private Book ZnajdzKsiazkePoId(sbyte id)
        {
            foreach (var book in Ksiazki)
            {
                if (book.Id == id)
                    return book;
            }
            return null;
        }

        
        public ObservableCollection<Book> Ksiazki1 { get; set; } = new ObservableCollection<Book>();

        public ObservableCollection<Book> ZnajdzKsiazkePoTytule(string tytul)
        {


            foreach (var book in Ksiazki)
            {
                Debug.WriteLine(book.Title);
                Debug.WriteLine(tytul);
                string i = book.Title;
                if (i.Contains(tytul))
                    Znalezione.Add(book);

            }
            return Znalezione;
        }


        public bool CzyKsiazkaJestJuzWRepozytorium(Book ksiazka) => Ksiazki.Contains(ksiazka);

        public bool DodajKsiazkeDoBazy(Book ksiazka)
        {
            if (!CzyKsiazkaJestJuzWRepozytorium(ksiazka))
            {
                if (BookRepository.AddBookToDataBase(ksiazka))
                {
                    Ksiazki.Add(ksiazka);
                    return true;
                }
            }
            return false;
        }

        public bool EdytujKsiazkeWBazie(Book ksiazka, sbyte idKsiazki)
        {
            if (BookRepository.EditBookInDataBase(ksiazka, idKsiazki))
            {
                for (int i = 0; i < Ksiazki.Count; i++)
                {
                    if (Ksiazki[i].Id == idKsiazki)
                    {
                        ksiazka.Id = idKsiazki;
                        Ksiazki[i] = new Book(ksiazka);
                    }
                }
                return true;
            }
            return false;
        }

        public void DodajKsiazkeDoPrzeczytania(Book ksiazka)
        {
            DoPrzeczytania.Add(ksiazka);
            BookUser user = new BookUser((sbyte)Session.CurrentUser.UserId, (sbyte)ksiazka.Id, false, true, 0);
            BookUserRepository.AddOwnershipToDataBase(user);
        }

        public void DodajKsiazkePrzeczytana(Book ksiazka)
        {
            Przeczytane.Add(ksiazka);
            BookUser user = new BookUser((sbyte)Session.CurrentUser.UserId, (sbyte)ksiazka.Id, true, false, 0);
            BookUserRepository.AddOwnershipToDataBase(user);
        }

    }
}

//public BookUser(sbyte userId, sbyte bookId, bool isRead, bool wantToRead, int rate = 0)
//{
//    BooksUsersId = null;
//    UserId = userId;
//    BookId = bookId;
//    IsRead = isRead;
//    WantToRead = wantToRead;
//    Rate = rate;
//}