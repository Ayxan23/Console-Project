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

        void CheckBalance();

        void TopUpBalance(double upBalance);

        void ChangePassword(string newPassword);

        void BankUserList();

        void BlockUser(string email);

    }
}
