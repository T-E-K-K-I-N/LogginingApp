using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LogginingApp.Data.Models
{
    public class Participant
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Обязательное поле Имя")]
        [MinLength(3, ErrorMessage = "Имя должно состоять минимум из 3 букв")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Обязательное поле Пол")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Обязательное поле Возраст")]
        public ushort? Age { get; set; }

        [Required(ErrorMessage = "Обязательное поле Стаж")]
        public ushort? Experience { get; set; }

        [Required(ErrorMessage = "Обязательное поле Город проживания")]
        public string ResidenceCity { get; set; }

        [Required(ErrorMessage = "Обязательное поле Email")]
        [EmailAddress(ErrorMessage = "Неферный формат Email адреса")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Обязательное поле Пароль")]
        [MinLength(6, ErrorMessage = "Пароль должен состоять минимум из 6 символов")]
        [MaxLength(24, ErrorMessage = "Пароль должен состоять максимум из 24 символов")]
        public string Password { get; set; }

    }
}