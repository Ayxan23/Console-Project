using Console_Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project.Services
{
    internal interface IAccountService
    {

        bool UserRegistration(string name, string surname, string email, string password, bool isAdmin);

        bool? UserLogin(string email, string password);

        void FindUser(string email);

    }
}
