using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModel
{
    using Model;
    using DAL.Entities;
    using BaseClass;
    using System.Windows.Input;
    using System.Collections.ObjectModel;

    class TabListaViewModel : BaseViewModel
    {
        private Model model = null;
        private ObservableCollection<Book> ksiazki = null;
        private ObservableCollection<Book> doPrzeczytania = Model.DoPrzeczytania;
        private ObservableCollection<Book> przeczytane = null;

        private int indeksZaznaczonejKsiazki = -1;

        public TabListaViewModel(Model model)
        {
            this.model = model;
            ksiazki = model.Ksiazki;
          
        }

        public int IndeksZaznaczonejKsiazki
        {
            get => indeksZaznaczonejKsiazki;
            set
            {
                indeksZaznaczonejKsiazki = value;
                onPropertyChanged(nameof(IndeksZaznaczonejKsiazki));
            }
        }


       

        public static Book BiezacaKsiazka { get; set; }


        public ObservableCollection<Book> Ksiazki
        {
            get { return ksiazki; }
            set
            {
                ksiazki = value;
                onPropertyChanged(nameof(Ksiazki));
            }
        }

        public ObservableCollection<Book> DoPrzeczytania
        {
            get { return doPrzeczytania; }
            set
            {
                doPrzeczytania = value;
                onPropertyChanged(nameof(DoPrzeczytania));
            }
        }

        public ObservableCollection<Book> Przeczytane
        {
            get { return przeczytane; }
            set
            {
                przeczytane = value;
                onPropertyChanged(nameof(Przeczytane));
            }
        }

        private ICommand zaladujWyszystkieKsiazki = null;
        public ICommand ZaladujWszystkieKsiazki
        {
            get
            {
                if (zaladujWyszystkieKsiazki == null)
                    zaladujWyszystkieKsiazki = new RelayCommand(
                        arg =>
                        {
                            Ksiazki = model.Ksiazki;

                        },
                        arg => true
                        );

                return zaladujWyszystkieKsiazki;
            }
        }
        public void OdswiezKsiazki() => Ksiazki = model.Ksiazki;

       

    }
}
