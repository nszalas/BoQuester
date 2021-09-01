using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1.ViewModel
{
    using ViewModel.BaseClass;
    using Model;
    using WpfApp1.DAL.Entities;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;

    class LoginScreen:BaseViewModel
    {
        #region private
        private Model model = new Model();
        private string username;
        private bool isWindowVisible = true;
        #endregion

        #region constructors

        public LoginScreen(Model model)
        {
            this.model = model;
            Users = model.Users;
        }

        #endregion

        #region Properties

        public ObservableCollection<User> Users { get; set; }

        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                onPropertyChanged(nameof(Username));
            }
        }

        public bool IsWindowVisible
        {
            get { return isWindowVisible; }
            set
            {
                isWindowVisible = value;
                onPropertyChanged(nameof(IsWindowVisible));
            }
        }
        #endregion

        private ICommand correctPassword = null;

        public ICommand CorrectPassword => correctPassword ?? (
            correctPassword = new RelayCommand(checkCorrectPassword, p => true)
        );
        
        private void checkCorrectPassword(object param)
        {
            var passBox = param as PasswordBox;
            string password = passBox.Password;
            if(model.CorrectPassword(Username, password))
            {
                MessageBox.Show("Correct");              
                MainWindow app = new MainWindow();
                IsWindowVisible = false;
                app.Show();                        
            }
            else
            {
                MessageBox.Show("Password or username is not correct");
            }
        }

      

    }
}
