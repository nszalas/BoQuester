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
    using System.ComponentModel;
    using System.Diagnostics;

    class SzukajKsiazki : BaseViewModel
    {
        private Model model = null;

        private string title1, releaseDate, category, description;
        private int publisher;
        public SzukajKsiazki(Model model)
        {
            this.model = model;
            Info = this.Info;
        }

        public Book Ksiazka { get; set; }

        public string Title1
        {
            get { return title1; }
            set
            {
                Debug.WriteLine(value);
                title1 = value;
                onPropertyChanged(nameof(Title1));
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

        

        //access do pola z info zwrotnym
        private ObservableCollection<Book> info;
        public ObservableCollection<Book> Info
        {
            get { return info; }
            set
            {
                info = value;
                onPropertyChanged(nameof(Info));
            }
        }

        

        


        private ICommand szukaj;

        public ICommand Szukaj
        {
            get
            {
                return szukaj ?? (szukaj = new RelayCommand(
                    p =>
                    {
                        Debug.WriteLine(Title1);
                        Info = model.ZnajdzKsiazkePoTytule(Title1);
                        
                    }, p => true));
                

            }
        }

        
    }
}
