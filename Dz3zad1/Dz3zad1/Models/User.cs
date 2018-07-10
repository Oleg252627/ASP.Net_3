using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dz3zad1.Models
{
    public class User
    {
        internal object id;

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Passvord { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Role Role { get; set; }

        public User( string firstName, string lastName, string login, string passvord, string email,
            string phone)
        {
            
            FirstName = firstName;
            LastName = lastName;
            Login = login;
            Passvord = passvord;
            Email = email;
            Phone = phone;
        }

        public void Add_Rol(Role role)
        {
            Role = role;
        }

        public void Renam_User(string firstName, string lastName, string login, string passvord, string email,
            string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Login = login;
            Passvord = passvord;
            Email = email;
            Phone = phone;
        }
    }
}