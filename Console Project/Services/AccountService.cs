using Console_Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project.Services
{
    internal class AccountService : IAccountService
    {
        User[] _users;

        public User[] Users => _users;

        public AccountService()
        {
            _users = new User[0];
        }

        public bool UserRegistration(string name, string surname, string email, string password, bool isAdmin)
        {
            User userNew = new User(name, surname, email, password, isAdmin);

            foreach (User user in _users)
            {
                if (userNew != user)
                {
                    Array.Resize(ref _users, _users.Length + 1);
                    _users[_users.Length - 1] = userNew;
                    return true;
                }
            }
            return false;
        }

        public bool UserLogin(string email, string password)
        {
            User? existed = null;
            foreach (User user in _users)
            {
                if (user.Email == email && user.Password == password)
                {
                    existed = user;
                }
            }
            if (existed == null)
            {
                return false;
            }
            return true;
        }

        public void FindUser(string email)
        {
            User? existed = null;
            foreach (User user in _users)
            {
                if (user.Email == email)
                {
                    existed = user;
                }
            }
            if (existed != null)
            {
                Console.WriteLine($"{existed.Name} {existed.Surname}");
            }
            else
            {
                Console.WriteLine(existed);
            }
        }



    }
}
