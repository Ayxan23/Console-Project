using Console_Project.Entities;
using Console_Project.Services;
using System.Runtime.ConstrainedExecution;

namespace Console_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int selection;

            account:
            do
            {
            start:
                Console.WriteLine("\n (Account Service)");
                Console.WriteLine("1. User Registration");
                Console.WriteLine("2. User Login");
                Console.WriteLine("3. Find User");
                Console.WriteLine("0. Exit");
                bool result = int.TryParse(Console.ReadLine(), out selection);
                if (result)
                {
                    switch (selection)
                    {
                        case 1:
                            MenuService.UserRegistration();
                            break;
                        case 2:
                            MenuService.UserLogin();
                            break;
                        case 3:
                            MenuService.FindUser();
                            break;
                        default:
                            Console.Clear();
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    goto start;
                }
            } while (selection != 0 && User.IsLogged != true);


            if (selection != 0)
            {
                do
                { 
                start2:
                    Console.WriteLine("\n (Bank Service)");
                    Console.WriteLine("1. Check Balance");
                    Console.WriteLine("2. Top Up Balance");
                    Console.WriteLine("3. Change Password");
                    Console.WriteLine("4. Bank User List");
                    Console.WriteLine("5. Block User");
                    Console.WriteLine("0. Log Out");
                    bool result = int.TryParse(Console.ReadLine(), out selection);
                    if (result)
                    {
                        switch (selection)
                        {
                            case 1:
                                MenuService.CheckBalance();
                                break;
                            case 2:
                                MenuService.TopUpBalance();
                                break;
                            case 3:
                                MenuService.ChangePassword();
                                break;
                            case 4:
                                MenuService.BankUserList();
                                break;
                            case 5:
                                MenuService.BlockUser();
                                break;
                            case 0:
                                MenuService.LogOut();
                                Console.Clear();
                                break;
                            default:
                                Console.Clear();
                                break;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        goto start2;
                    }
                } while (selection != 0);
                goto account;
            }
        
        }
    }
}