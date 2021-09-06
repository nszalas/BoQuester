using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    using DAL.Entities;
    using DAL.Repositories;
    using System.Security.Authentication;

    class Session
    {
        private static User currentUser;
        private bool isAuthenticated;

        public bool IsAuthenticated
        {
            get { return isAuthenticated; }
        }

        public static User CurrentUser
        {
            get { return currentUser; }
        }

        private static Session instance = null;
        private Session(string username, string password)
        {
            currentUser = UserRepository.getUser(username);
            isAuthenticated = UserAuthentication.Authenticate(username, password);

            var toread = BookUserRepository.getListWantToRead(currentUser.UserId);
            foreach (var book in toread)
                Model.DoPrzeczytania.Add(book);
        }

        public static Session GetOrCreateSession(string username, string password)
        { 
            if(instance == null)
            {
                User tryUser = UserRepository.getUser(username);
                if (tryUser == null)
                {
                    throw new AuthenticationException("Username or password was incorrect");
                }
                else
                {
                    if (!UserAuthentication.Authenticate(username, password))
                    {
                        throw new AuthenticationException("Username or password was incorrect");
                    }
                    if(UserAuthentication.Authenticate(username, password))
                    {
                        instance = new Session(username, password);
                    }   
                }                                          
            }
            return instance;
        }
    }
}
