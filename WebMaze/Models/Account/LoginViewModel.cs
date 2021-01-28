using System.ComponentModel;

namespace WebMaze.Models.Account
{
    public class LoginViewModel
    {
        [DisplayName("Имя пользователя")]
        public string Login { get; set; }

        [DisplayName("Пароль")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}