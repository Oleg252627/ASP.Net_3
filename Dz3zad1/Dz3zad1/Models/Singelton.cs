using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dz3zad1.Models
{
    public class Singelton
    {
        public static Singelton _instens;
        public static Singelton Instens => _instens ?? (_instens = new Singelton());
        private Singelton() { }
        private List<User> users=new List<User>();

        private List<Role> roles = new List<Role>();

        public List<User> GetUsers() => users;

        public List<Role> GetRoles() => roles;

        public void AddUsers(User item)
        {
            item.Id = (users.LastOrDefault()?.Id ?? 0) + 1;
            users.Add(item);
        }

        public void AddRoles(Role item)
        {
            item.Id = (roles.LastOrDefault()?.Id ?? 0) + 1;
            roles.Add(item);
        }

    }
}