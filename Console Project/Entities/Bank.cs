using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project.Entities
{
    internal class Bank
    {

        public static User[] Users; 
        public static int Id;

        public Bank()
        {
            Users = new User[0];
            Id = 0;
        }
 
        static Bank()
        {
            Users = new User[0];
        }

    }
}
