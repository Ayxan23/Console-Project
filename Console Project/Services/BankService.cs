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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{existed.Balance}");
            Console.ResetColor();
        }


        public void TopUpBalance(double upBalance)
        {
            User? existed = MenuService.LoggedUser;
            existed.Balance += upBalance;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"\nArtirilmis hali: {existed.Balance}");
            Console.ResetColor();
        }


        public void ChangePassword(string newPassword)
        {
            User? existed = MenuService.LoggedUser;
            if (existed.Password == newPassword)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Yeni password evvelki ile eynidir!");
                Console.ResetColor();
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
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"Id:{user.IdGet} {user.Name} {user.Surname}");
                    Console.ResetColor();
                }
            }
            else if (existed.IsAdmin == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Yalniz admin olan user istifade ede biler!");
                Console.ResetColor();
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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\n{user.Name} is blocked");
                        Console.ResetColor();
                        return;
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Bu email'e sahib olan user yoxdur!");
            Console.ResetColor();
        }


        public void LogOut()
        {
            User.IsLogged = false;
        }

    }
}
