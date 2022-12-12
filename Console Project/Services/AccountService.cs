using Console_Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Console_Project.Services
{
    internal class AccountService : IAccountService
    {

        public bool UserRegistration(string name, string surname, string email, string password, bool isAdmin)
        {
            foreach (User user in Bank.Users)
            {
                if (email == user.Email)
                {
                    return false;
                }
            }
            User userNew = new User(name, surname, email, password, isAdmin); 
            return true;
        }

        public bool? UserLogin(string email, string password)
        {
            User? existed = null;
            foreach (User user in Bank.Users)
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
            if (existed.IsBlocked == true)
            {
                return null;
            }
            User.IsLogged = true;
            MenuService.LoggedUser = existed;
            return true;
        }

        public void FindUser(string email)
        {
            User? existed = null;
            foreach (User user in Bank.Users)
            {
                if (user.Email == email)
                {
                    existed = user;
                }
            }
            if (existed != null)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Id:{existed.IdGet} {existed.Name} {existed.Surname}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine(existed);
            }
        }

    }
}
