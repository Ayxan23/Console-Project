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
        public double Balance;
        public string Email;
        public string Password;
        public bool IsAdmin;
        public bool IsBlocked;
        public bool IsLogged;

    }
}
