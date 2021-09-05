using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModel
{
    using BaseClass;
    using WpfApp1.Model;
    using WpfApp1.DAL.Entities;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    class SzukajKsiazki : BaseViewModel
    {
        private Model model = null;

        private string title, releaseDate, category, description;
        private int publisher;
        public SzukajKsiazki(Model model)
        {
            this.model = model;

        }

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                onPropertyChanged(nameof(Title));
            }
        }
        public string ReleaseDate
        {
            get { return releaseDate; }
            set
            {
                releaseDate = value;
                onPropertyChanged(nameof(ReleaseDate));
            }
        }

        public int Publisher
        {
            get { return publisher; }
            set
            {
                publisher = value;
                onPropertyChanged(nameof(Publisher));
            }
        }

        public string Category
        {
            get { return category; }
            set
            {
                category = value;
                onPropertyChanged(nameof(Category));
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                onPropertyChanged(nameof(Description));
            }
        }

        private ICommand szukaj;

        public ICommand Szukaj
        {
            get
            {
                *tutaj wyszukanie w konkretnej kolumnie
                if(znajdzie )
                    too wyswietla dane
                if nie
                    napis "brak takiej ksiazki w bazie"

            }
        }
    }
}
