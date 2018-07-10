using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Dz3zad1.Models
{
    public class ModelUser
    {
        [Required(ErrorMessage = "Заполните поле Имя")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Заполните поле Фамилия")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Заполните поле Логин")]
        [StringLength(20,MinimumLength = 5,ErrorMessage = "Поле логин должно быть от 5 до 20 символов")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Заполните поле Пароль")]
        [StringLength(30,MinimumLength = 6,ErrorMessage = "Поле пароль должно быть от 5 до 30 символов")]
        public string Passvord { get; set; }
        [Required(ErrorMessage = "Заполните поле Почта")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",ErrorMessage = "Не коректная почта")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Заполните поле Тулефон")]
        public string Phone { get; set; }

        public string role { get; set; }
    }
}