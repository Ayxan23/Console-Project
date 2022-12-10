using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project.Entities
{
    internal class Bank
    {
        public int Id;
        public User[] Users;
        static int id = 0;

        public Bank()
        {
            Users = new User[0];
        }
        

        public void AddUser(User user)
        {
            Array.Resize(ref Users, Users.Length + 1);
            Users[Users.Length - 1] = user;
            user.Id = id++;
            Id = id;
        }


        public void IdFinder(User user)
        {
            int userId = user.Id;
        }


    }
}
