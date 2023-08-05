using System.ComponentModel.DataAnnotations;

namespace Identity.Models.DTOs
{
    public class RegisterDTO
    {
        //bunların hepsi IdentyUser de var ama ben dto oluşturuyorum.
        //burada gerkli validasyonlarımı yapacağım

        [Required(ErrorMessage ="Kullanıcı Adı Yazınız")]
        [MinLength(3,ErrorMessage ="En az 3 karakter yazmalısınız")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifrenizi yazınız")]
        [MaxLength(4, ErrorMessage = "Max 4 karakter yazmalısınız")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Mailinizi")]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }
    }
}
