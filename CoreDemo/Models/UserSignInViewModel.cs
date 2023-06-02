using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı girin")]
        public string username { get; set; }

        [Required(ErrorMessage = "Şifre girin")]
        public string password { get; set; }
    }
}
