using Console_Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Console_Project.Services
{
    internal static class MenuService
    {

        static AccountService _accountService;
        static BankService _bankService;
        public static User LoggedUser;

        static MenuService()
        {
            _accountService = new AccountService();
            _bankService = new BankService();
        }


        public static void UserRegistration()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n(User Registration)");
            Console.ResetColor();
            name:
            Console.WriteLine("\nPlease enter Name:");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                goto name;
            }
            if (name.Length < 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Name'in minimum uzunluqu 3 olmalıdır!");
                Console.ResetColor();
                goto name;
            }
            surname:
            Console.WriteLine("\nPlease enter Surname:");
            string surname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(surname))
            {
                goto surname;
            }
            if (surname.Length < 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Surname'in minimum uzunluqu 3 olmalıdır!");
                Console.ResetColor();
                goto surname;
            }
            email:
            Console.WriteLine("\nPlease enter Email:");
            string email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email))
            {
                goto email;
            }
            if (!checkEmail(email))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Email'in icerisinde 1 eded '@' ve '.' isaresi olmalidir!");
                Console.ResetColor();
                goto email;
            }
            password:
            Console.WriteLine("\nPlease enter Password:");
            string password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password))
            {
                goto password;
            }
            if (!checkPassword(password))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Password'un minimum uzunluq 8 olmalidir, icerisinde minimum 1 herf kicik, minimum 1 herf boyuk olmalidir!");
                Console.ResetColor();
                goto password;
            }
            isAdmin:
            Console.WriteLine("\nAre you an Admin? (Yes or No)");
            bool nAdmin = false;
            string Admin = Console.ReadLine();
            if (Admin != "Yes" && Admin != "No")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter: Yes or No!");
                Console.ResetColor();
                goto isAdmin;
            }
            if (Admin == "Yes")
            {
                nAdmin = true;
            }
            bool result = _accountService.UserRegistration(name, surname, email, password, nAdmin);
            if (result == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Duplicate Email ola bilmez!");
                Console.ResetColor();
            }
            else if (result == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nRegistration ugurla tamamlandi!");
                Console.ResetColor();
            }
        }


        public static void UserLogin()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n(User Login)");
            Console.ResetColor();
            email:
            Console.WriteLine("\nPlease enter Email:");
            string email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email))
            {
                goto email;
            }
            if (!checkEmail(email))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Email'in icerisinde 1 eded '@' ve '.' isaresi olmalidir!");
                Console.ResetColor();
                goto email;
            }
            password:
            Console.WriteLine("\nPlease enter Password:");
            string password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password))
            {
                goto password;
            }
            if (!checkPassword(password))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Password'un minimum uzunluq 8 olmalidir, icerisinde minimum 1 herf kicik, minimum 1 herf boyuk olmalidir!");
                Console.ResetColor();
                goto password;
            }
            bool? result = _accountService.UserLogin(email, password);
            if (result == null)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("User block olunub!");
                Console.ResetColor();
            }
            else if (result == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Email veya Password yanlisdir!");
                Console.ResetColor();
            }
            else if (result == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nLogin oldunuz!");
                Console.ResetColor();
            }
        }


        public static void FindUser()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n(Find User)");
            Console.ResetColor();
            email:
            Console.WriteLine("\nPlease enter Email:");
            string email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email))
            {
                goto email;
            }
            if (!checkEmail(email))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Email'in icerisinde 1 eded '@' ve '.' isaresi olmalidir!");
                Console.ResetColor();
                goto email;
            }
            _accountService.FindUser(email);
        }


        public static void CheckBalance()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n(Check Balance)");
            Console.ResetColor();
            _bankService.CheckBalance();
        }


        public static void TopUpBalance()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n(Top Up Balance)");
            Console.ResetColor();
            upBalance:
            Console.WriteLine("\nArtirmaq istediyiniz mebleg:");
            bool upBalanceResult = double.TryParse(Console.ReadLine(), out double balance);
            if (!upBalanceResult || balance < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter valid balance!");
                Console.ResetColor();
                goto upBalance;
            }
            _bankService.TopUpBalance(balance);
        }


        public static void ChangePassword()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n(Change Password)");
            Console.ResetColor();
            password:
            Console.WriteLine("\nPlease enter Password:");
            string password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password))
            {
                goto password;
            }
            if (!checkPassword(password))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Password'un minimum uzunluq 8 olmalidir, icerisində minimum 1 herf kicik, minimum 1 herf boyuk olmalidir!");
                Console.ResetColor();
                goto password;
            }
            _bankService.ChangePassword(password);
        }


        public static void BankUserList()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n(Bank User List)");
            Console.ResetColor();
            _bankService.BankUserList();
        }


        public static void BlockUser()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n(Block User)");
            Console.ResetColor();
            if (LoggedUser.IsAdmin == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Yalniz admin olan user istifade ede biler!");
                Console.ResetColor();
                return;
            }
            email:
            Console.WriteLine("\nPlease enter Email:");
            string email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email))
            {
                goto email;
            }
            if (!checkEmail(email))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Email'in icerisinde 1 eded '@' ve '.' isaresi olmalidir!");
                Console.ResetColor();
                goto email;
            }
            _bankService.BlockUser(email);
        }


        public static void LogOut()
        {
            _bankService.LogOut();
        }



        static bool checkEmail(string email)
        {
            bool result = false;

            if (email.Length >= 5)
            {
                bool isMail = false;
                bool isDot = false;
                foreach (char item in email)
                {
                    if (item == '@')
                    {
                        isMail = true;
                    }
                    if (item == '.')
                    {
                        isDot = true;
                    }
                }
                result = isDot && isMail;
                return result;
            }
            else
            {
                return result;
            }
        } 

        static bool checkPassword(string pass)
        {
            bool result = false;

            if (pass.Length >= 8)
            {
                bool isUpper = false;
                bool isLower = false;
                foreach (char item in pass)
                {
                    if (char.IsUpper(item))
                    {
                        isUpper = true;
                    }
                    if (char.IsLower(item))
                    {
                        isLower = true;
                    }
                }
                result = isLower && isUpper;
                return result;
            }
            else
            {
                return result;
            }
        }

    }
}
