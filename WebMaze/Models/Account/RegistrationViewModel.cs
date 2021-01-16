using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.Models.CustomAttribute;

namespace WebMaze.Models.Account
{
    public class RegistrationViewModel
    {
        public long Id { get; set; }

        [MinLength(2, ErrorMessage = "Не бывает людей с именем из 2 букв")]
        [UniqUserName]
        [DisplayName("Имя пользователя")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Пароль для пользователя очень важен. Не оставляйте поле пустым")]
        [AtleastOneCapital(ErrorMessage = "Это другое сообщение про больую букву")]
        [DisplayName("Пароль")]
        public string Password { get; set; }

        [Compare("Password")]
        public string RepeatPassword { get; set; }
    }
}
