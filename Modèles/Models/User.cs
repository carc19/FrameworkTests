using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modèles.Models
{
    public class User
    {
        public string Email { get; set; }
        public string Pwd { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public User()
        {

        }

        public User(string email, string pwd, string firstName, string lastName)
        {
            Email = email;
            Pwd = pwd;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
