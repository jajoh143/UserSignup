using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserSignup.Models;

namespace UserSignup.Models
{
    public interface IUserData
    {
        List<User> Users { get; set; }
        void AddUser(User user);
    }

    public class UserData : IUserData
    {
        public List<User> Users { get
            {
                return this.Users;
            }
            set { }
        }

        public void AddUser(User user)
        {
            this.Users.Add(user);
        }
    }

    
}