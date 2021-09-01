using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModel
{
    using Model;
    class MainViewModel
    {
        private Model model = new Model();
        public LoginScreen LoginScreenVM { get; set; }

        public MainViewModel()
        {
            LoginScreenVM = new LoginScreen(model);
        }
    }
}
