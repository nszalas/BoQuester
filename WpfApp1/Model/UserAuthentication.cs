using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    using DAL.Repositories;
    using DAL.Entities;
    using System.Security.Cryptography;

    static class UserAuthentication
    {

        public static bool Authenticate(string username, string password)
        {
            bool isAuthenticated = false;
            User user = UserRepository.getUser(username);
            string dataBasePassword = user.Password;

            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hashedPassword;

            hashedPassword = algorithm.ComputeHash(Encoding.ASCII.GetBytes(password));

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < hashedPassword.Length; i++)
            {
                builder.Append(hashedPassword[i].ToString("x2"));
            }
            password = builder.ToString();

            if (dataBasePassword == password)
                isAuthenticated = true;

            return isAuthenticated;
        }
    }
}
