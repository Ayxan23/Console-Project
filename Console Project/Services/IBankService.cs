using Console_Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project.Services
{
    internal interface IBankService
    {
        User User { get;  }   

        void CheckBalance(User user);

        void TopUpBalance(User user);

        void ChangePassword(User user);

        void BankUserList(User[] user, bool isAdmin);

        void BlockUser(string email, bool isAdmin);


    }
}
