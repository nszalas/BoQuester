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

    class Model
    {
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();

        // get data from database to collection
        public Model()
        {
            var users = UserRepository.getUsers();
            foreach (var user in users)
                Users.Add(user);
        }


    }
}
