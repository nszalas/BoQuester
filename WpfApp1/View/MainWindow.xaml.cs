using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //List<int> lista_rok = new List<int>();
        //List<int> lista_miesiac = new List<int>();
        //List<int> lista_dzien = new List<int>();
        List<int> lista_wydawnictwo = new List<int>();
        public MainWindow()
        {
            InitializeComponent();

            //for (int i = 1; i <= 31; i++)
            //{
            //    lista_dzien.Add(i);
            //}
            //cb_dzien.ItemsSource = lista_dzien;

            //for (int i = 1; i <= 12; i++)
            //{
            //    lista_miesiac.Add(i);
            //}
            //cb_miesiac.ItemsSource = lista_miesiac;

            //for (int i = 2021; i >= 1900; i--)
            //{
            //    lista_rok.Add(i);
            //}
            //cb_rok.ItemsSource = lista_rok;

            for (int i = 1; i <= 6; i++)
            {
                lista_wydawnictwo.Add(i);
            }
            cb_publisher.ItemsSource = lista_wydawnictwo;

        }
    }
}
