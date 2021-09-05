using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModel
{
    using Model;
    using WpfApp1.DAL.Entities;
    using BaseClass;
    using System.ComponentModel;

    class MainViewModel 
    {
        private Model model = new Model();
        public LoginScreen LoginScreenVM { get; set; }
        public TabListaViewModel TabListaVM { get; set; }
        public TabDodajKsiazkiViewModel TabDodajKsiazkiVM { get; set; }
        public SzukajKsiazki SzukajKsiazki { get; set; }

        //private List<Book> books;

        //public event PropertyChangedEventHandler PropertyChanged;

        //public List<Book> Books
        //{
        //    get { return books; }
        //    set
        //    {
        //        books = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Books)));
        //    }
        //}

        public MainViewModel()
        {
            //Books = WpfApp1.DAL.Repositories.BookRepository.getBooks();
            LoginScreenVM = new LoginScreen(model);
            TabListaVM = new TabListaViewModel(model);
            TabDodajKsiazkiVM = new TabDodajKsiazkiViewModel(model);
            SzukajKsiazki = new SzukajKsiazki(model);

        }
    }
}
