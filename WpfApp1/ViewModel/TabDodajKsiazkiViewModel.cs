using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1.ViewModel
{
    using BaseClass;
    using WpfApp1.Model;
    using WpfApp1.DAL.Entities;
    using System.Collections.ObjectModel;
    class TabDodajKsiazkiViewModel : BaseViewModel
    {
        private Model model = null;

        private string title, releaseDate, category, description;
        private int publisher, idZaznaczenia = -1;
        private bool dodawanieDostepne = true;
        private bool edycjaDostepna = false;

        public TabDodajKsiazkiViewModel(Model model)
        {
            this.model = model;
            Ksiazki = model.Ksiazki;
        }


        public static Book BiezacaKsiazka { get; set; } 

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

       
        public int IdZaznaczenia
        {
            get { return idZaznaczenia; }
            set
            {
                idZaznaczenia = value;
                onPropertyChanged(nameof(IdZaznaczenia));
            }
        }

        public ObservableCollection<Book> Ksiazki { get; set; }

        public bool DodawanieDostepne
        {
            get { return dodawanieDostepne; }
            set
            {
                dodawanieDostepne = value;
                onPropertyChanged(nameof(DodawanieDostepne));
            }
        }

        public bool EdycjaDostepna
        {
            get { return edycjaDostepna; }
            set
            {
                edycjaDostepna = value;
                onPropertyChanged(nameof(EdycjaDostepna));
            }
        }


        private ICommand dodaj = null;

        public ICommand Dodaj
        {

            get
            {
                if (dodaj == null)
                    dodaj = new RelayCommand(
                        arg =>
                        {
                            var ksiazka = new Book(Title, ReleaseDate, (sbyte)Publisher, Category, Description);

                            if (model.DodajKsiazkeDoBazy(ksiazka))
                            {
                                CzyscFormularz();
                                System.Windows.MessageBox.Show("Pozycja została dodana do bazy");
                            }
                        }
                        ,
                        arg => (Title != "") && (ReleaseDate != "") && (Category != "") && (Description != "")
                        );


                return dodaj;
            }

        }
       

        private ICommand edytuj = null;

        public ICommand Edytuj
        {
            get
            {
                if (edytuj == null)
                    edytuj = new RelayCommand(
                    arg =>
                    {
                        model.EdytujKsiazkeWBazie(new Book(Title, ReleaseDate, (sbyte)Publisher, Category, Description), (sbyte)BiezacaKsiazka.Id);
                        IdZaznaczenia = -1;
                        DodawanieDostepne = true;
                    }
                         ,
                    arg => (BiezacaKsiazka?.Title != Title) || (BiezacaKsiazka?.ReleaseDate != ReleaseDate) || (BiezacaKsiazka?.Publisher != Publisher) || (BiezacaKsiazka?.Category !=Category) || (BiezacaKsiazka?.Description != Description) 
                   );


                return edytuj;
            }
        }

        private void CzyscFormularz()
        {
            Title = "";
            ReleaseDate = "";
            Publisher = 0;
            Category = "";
            Description = "";
            DodawanieDostepne = true;
            EdycjaDostepna = false;
        }

        private ICommand ladujFormularz = null;
        public ICommand LadujFormularz
        {

            get
            {
                if (ladujFormularz == null)
                    ladujFormularz = new RelayCommand(
                        arg =>
                        {
                            if (IdZaznaczenia > -1)
                            {
                                Title = BiezacaKsiazka.Title;
                                ReleaseDate = BiezacaKsiazka.ReleaseDate;
                                Publisher = BiezacaKsiazka.Publisher;
                                Category = BiezacaKsiazka.Category;
                                Description = BiezacaKsiazka.Description;
                                DodawanieDostepne = false;
                                EdycjaDostepna = true;
                            }
                            else
                            {
                                Title = "";
                                ReleaseDate = "";
                                Publisher = 0;
                                Category = "";
                                Description = "";
                                DodawanieDostepne = true;
                                EdycjaDostepna = false;
                            }
                        }
                        ,
                        arg => true
                        );


                return ladujFormularz;
            }
        }


        private ICommand dodaj_doPrzeczytania = null;

        public ICommand Dodaj_doPrzeczytania
        {

            get
            {
                if (dodaj_doPrzeczytania == null)
                    dodaj_doPrzeczytania = new RelayCommand(
                        arg =>
                        {

                            model.DodajKsiazkeDoPrzeczytania(TabListaViewModel.BiezacaKsiazka);  
                            IdZaznaczenia = -1;
                        }
                        ,
                        arg => true
                        );


                return dodaj_doPrzeczytania;
            }

        }

        private ICommand dodaj_Przeczytane = null;

        public ICommand Dodaj_Przeczytane
        {

            get
            {
                if (dodaj_Przeczytane == null)
                    dodaj_Przeczytane = new RelayCommand(
                        arg =>
                        {

                            model.DodajKsiazkePrzeczytana(TabListaViewModel.BiezacaKsiazka);
                            IdZaznaczenia = -1;
                        }
                        ,
                        arg => true
                        );


                return dodaj_Przeczytane;
            }

        }

        private ICommand usun_ksiazke = null;

        public ICommand Usun_ksiazke
        {

            get
            {
                if (usun_ksiazke == null)
                    usun_ksiazke = new RelayCommand(
                        arg =>
                        {
                            if (arg.ToString() == "usun_do_przeczytania") 
                                model.UsunKsiazke(TabListaViewModel.BiezacaKsiazka, Model.DoPrzeczytania);
                            else
                                model.UsunKsiazke(TabListaViewModel.BiezacaKsiazka, Model.Przeczytane);
                            IdZaznaczenia = -1;
                        }
                        ,
                        arg => true
                        );


                return usun_ksiazke;
            }

        }

        //private ICommand usun_ksiazke_przeczytana = null;

        //public ICommand Usun_ksiazke_przeczytana
        //{

        //    get
        //    {
        //        if (usun_ksiazke_przeczytana == null)
        //            usun_ksiazke_przeczytana = new RelayCommand(
        //                arg =>
        //                {
        //                    model.UsunKsiazke(TabListaViewModel.BiezacaKsiazka, Model.DoPrzeczytania);
        //                    IdZaznaczenia = -1;
        //                }
        //                ,
        //                arg => true
        //                );


        //        return usun_ksiazke_przeczytana;
        //    }

        //}


    }
}
