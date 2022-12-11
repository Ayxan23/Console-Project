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
            Console.WriteLine("\n(User Registration)");
            name:
            Console.WriteLine("\nPlease enter Name:");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                goto name;
            }
            if (name.Length < 3)
            {
                Console.WriteLine("\nName'in minimum uzunluqu 3 olmalıdır!\n");
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
                Console.WriteLine("\nSurname'in minimum uzunluqu 3 olmalıdır!\n");
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
                Console.WriteLine("\nEmail'in icerisinde 1 eded '@' ve '.' isaresi olmalidir!\n");
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
                Console.WriteLine("\nPassword'un minimum uzunluq 8 olmalidir, icerisinde minimum 1 herf kicik, minimum 1 herf boyuk olmalidir!\n");
                goto password;
            }
            isAdmin:
            Console.WriteLine("\nAre you an Admin? (Yes or No)");
            bool nAdmin = false;
            string Admin = Console.ReadLine();
            if (Admin != "Yes" && Admin != "No")
            {
                Console.WriteLine("\nPlease enter: Yes or No!\n");
                goto isAdmin;
            }
            if (Admin == "Yes")
            {
                nAdmin = true;
            }
            bool result = _accountService.UserRegistration(name, surname, email, password, nAdmin);
            if (result == false)
            {
                Console.WriteLine("\nDuplicate Email ola bilmez!\n");
            }
            else if (result == true)
            {
                Console.WriteLine("\nRegistration ugurla tamamlandi!\n");
            }
        }


        public static void UserLogin()
        {
            Console.WriteLine("\n(User Login)");
            email:
            Console.WriteLine("\nPlease enter Email:");
            string email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email))
            {
                goto email;
            }
            if (!checkEmail(email))
            {
                Console.WriteLine("\nEmail'in icerisinde 1 eded '@' ve '.' isaresi olmalidir!\n");
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
                Console.WriteLine("\nPassword'un minimum uzunluq 8 olmalidir, icerisinde minimum 1 herf kicik, minimum 1 herf boyuk olmalidir!\n");
                goto password;
            }
            bool? result = _accountService.UserLogin(email, password);
            if (result == null)
            {
                Console.WriteLine("\nUser block olunub!\n");
            }
            else if (result == false)
            {
                Console.WriteLine("\nEmail veya Password yanlisdir!\n");
            }
            else if (result == true)
            {
                Console.WriteLine("\nLogin oldunuz!\n");
            }
        }


        public static void FindUser()
        {
            Console.WriteLine("\n(Find User)");
            email:
            Console.WriteLine("\nPlease enter Email:");
            string email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email))
            {
                goto email;
            }
            if (!checkEmail(email))
            {
                Console.WriteLine("\nEmail'in icerisinde 1 eded '@' ve '.' isaresi olmalidir!\n");
                goto email;
            }
            _accountService.FindUser(email);
        }


        public static void CheckBalance()
        {
            Console.WriteLine("\n(Check Balance)");
            _bankService.CheckBalance();
        }


        public static void TopUpBalance()
        {
            Console.WriteLine("\n(Top Up Balance)");
            upBalance:
            Console.WriteLine("\nArtirmaq istediyiniz mebleg:");
            bool upBalanceResult = double.TryParse(Console.ReadLine(), out double balance);
            if (!upBalanceResult || balance < 0)
            {
                Console.WriteLine("\nPlease enter valid balance!\n");
                goto upBalance;
            }
            _bankService.TopUpBalance(balance);
        }


        public static void ChangePassword()
        {
            Console.WriteLine("\n(Change Password)");
            password:
            Console.WriteLine("\nPlease enter Password:");
            string password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password))
            {
                goto password;
            }
            if (!checkPassword(password))
            {
                Console.WriteLine("\nPassword'un minimum uzunluq 8 olmalidir, icerisində minimum 1 herf kicik, minimum 1 herf boyuk olmalidir!\n");
                goto password;
            }
            _bankService.ChangePassword(password);
        }


        public static void BankUserList()
        {
            Console.WriteLine("\n(Bank User List)");
            _bankService.BankUserList();
        }


        public static void BlockUser()
        {
            Console.WriteLine("\n(Block User)");
            email:
            Console.WriteLine("\nPlease enter Email:");
            string email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email))
            {
                goto email;
            }
            if (!checkEmail(email))
            {
                Console.WriteLine("\nEmail'in icerisinde 1 eded '@' ve '.' isaresi olmalidir!\n");
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
