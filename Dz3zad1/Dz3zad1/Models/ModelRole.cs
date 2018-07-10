using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Dz3zad1.Models
{
    public class ModelRole
    {
        [Required(ErrorMessage = "Заполните поле имя Роли")]
        public string Name { get; set; }
    }
}