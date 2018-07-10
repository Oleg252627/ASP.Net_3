using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dz3zad1.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Role(string name)
        {
            Name = name;
        }

        public void Renem_Role(string name)
        {
            Name = name;
        }
    }
}