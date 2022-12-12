using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project.Entities
{
    internal class User
    {

        int _id;
        string _name;
        string _surname;
        string _email;
        string _password;
        public double Balance;
        public bool IsAdmin;
        public bool IsBlocked;
        public static bool IsLogged; 

        public int IdGet
        {
            get
            {
                return _id; 
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length >= 3)
                {
                    _name = value;
                }
                else
                {
                    Console.WriteLine("Name'in minimum uzunluqu 3 olmalidir");
                }
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                if (value.Length >= 3)
                {
                    _surname = value;
                }
                else
                {
                    Console.WriteLine("Surname'in minimum uzunluqu 3 olmalidir");
                }
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (checkPassword(value))
                {
                    _password = value;
                }
                else
                {
                    Console.WriteLine("Password'un minimum uzunluq 8 olmalıdır, içərisində minimum 1 hərf kiçik, minimum 1 hərf böyük olmalıdır");
                }
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (checkEmail(value))
                {
                    _email = value;
                }
                else
                {
                    Console.WriteLine("Email'in içərisində 1 ədəd '@' işarəsi olmalıdır və sistemdə duplicate email ola bilməz");
                }
            }
        }


        public User(string name, string surname, string email, string password, bool isAdmin)
        {
            _id = ++Bank.Id;
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            Balance = 0;
            IsAdmin = isAdmin;
            IsBlocked = false;
            Array.Resize(ref Bank.Users, Bank.Users.Length + 1);
            Bank.Users[Bank.Users.Length - 1] = this; 
        }

        static User()
        {
            IsLogged = false;
        }



        bool checkEmail(string email)
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

        bool checkPassword(string pass)
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
