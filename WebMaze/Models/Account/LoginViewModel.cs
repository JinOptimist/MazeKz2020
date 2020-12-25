using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.Models.CustomAttribute;

namespace WebMaze.Models.Account
{
    public class LoginViewModel
    {
        public long Id { get; set; }

        [DisplayName("Имя пользователя")]
        public string Login { get; set; }

        [DisplayName("Пароль")]
        public string Password { get; set; }

        public string RepeatPassword { get; set; }
    }
}
