using Console_Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project.Services
{
    internal class BankService : IBankService
    {

        public void CheckBalance()
        {
            Console.Write("\nBalance: ");
            User? existed = MenuService.LoggedUser; 
            Console.WriteLine($"{existed.Balance}");
        }


        public void TopUpBalance(double upBalance)
        {
            User? existed = MenuService.LoggedUser;
            existed.Balance += upBalance;
            Console.WriteLine($"\nArtirilmis hali: {existed.Balance}");
        }


        public void ChangePassword(string newPassword)
        {
            User? existed = MenuService.LoggedUser;
            if (existed.Password == newPassword)
            {
                Console.WriteLine("\nYeni password evvelki ile eynidir!\n");
            }
            if (existed.Password != newPassword)
            {
                existed.Password = newPassword;
            }
        }


        public void BankUserList() 
        {
            User? existed = MenuService.LoggedUser;
            if (existed.IsAdmin == true)
            {
                Console.WriteLine("\nUsers:");
                foreach (User user in Bank.Users)
                {
                    Console.WriteLine($"Id:{user.IdGet} {user.Name} {user.Surname}");
                }
            }
            else if (existed.IsAdmin == false)
            {
                Console.WriteLine("\nYalniz admin olan user istifade ede biler!\n");
            }
        }


        public void BlockUser(string email)
        {
            User? existed = MenuService.LoggedUser;
            if (existed.IsAdmin == true)
            {
                foreach (User user in Bank.Users)
                {
                    if (user.Email == email)
                    {
                        user.IsBlocked = true;
                        Console.WriteLine($"\n{user.Name} is blocked");
                        return;
                    }
                }
            }
            else if (existed.IsAdmin == false)
            {
                Console.WriteLine("\nYalniz admin olan user istifade ede biler!\n");
            }
            Console.WriteLine("\nBu email'e sahib olan user yoxdur");
        }


        public void LogOut()
        {
            User.IsLogged = false;
        }

    }
}
