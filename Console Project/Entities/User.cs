using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project.Entities
{
    internal class User
    {
        public int Id;
        public string Name;
        public string Surname;
        public string Email;
        public string Password;
        public bool IsAdmin;
        public double Balance;
        public bool IsBlocked;
        public bool IsLogged;

        public User(string name, string surname, string email, string password, bool isAdmin)
        {
            IsAdmin = isAdmin;
            
        }
    }
}
