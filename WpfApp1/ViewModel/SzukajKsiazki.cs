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

    class SzukajKsiazki : BaseViewModel
    {
        private Model model = null;

        private string title, releaseDate, category, description;
        private int publisher;
        public SzukajKsiazki(Model model)
        {
            this.model = model;
            
        }

        public Book Ksiazka { get; set; }

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

        

        //acces do pola z info zwrotnym
        private string info = " ";
        public string Info
        {
            get { return info; }
            set
            {
                info = value;
                onPropertyChanged(nameof(Info));
            }
        }

        private string tytul = "";
        public string Tytul1
        {
            get { return tytul; }
            set
            {
                tytul = value;
                onPropertyChanged(nameof(Tytul1));
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
                        if (model.ZnajdzKsiazkePoTytule(Tytul1) == null)
                        {
                            Info = "Brak";
                        }
                        else
                        {
                            Info = model.ZnajdzKsiazkePoTytule(Tytul1).ToString();
                        };

                    }, p => true));
                

            }
        }

        
    }
}
