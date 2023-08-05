using System.ComponentModel.DataAnnotations;

namespace Identity.Models.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Bu alan Boş Bırakılamaz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifrenizi Yazınız")]
        public string Password { get; set; }

        //Login actionuna x controllerın y actionından gitmek isteyen yada direkt olarak account/logine gelmek isteyen bir kişi olabilir. Kişi logini başarılı şekilde bitirdikten sonra doğrudan istediği adrese gidebilir yada anasayfaya yönlendirilebilir.

        //örnek veriyorum kişi category kontroller / update actionına gitmek isteyebilir ancak biz o kontrollera authorize verdiysek önce kişi kendini tanıtması için logine yönlendirilir ve gitmek istediği adres returnUrl propunda category/update diye tutulur. Login başarılı olursa kayırlı adrese yönlendirilir. Direk account/login isteğiyle geldiyse returnUrl null olacağından anasayfaya yönlenir. Bu yüzden propertye required diyemem illa dolu olmak zorunda değildir.
        public string ReturnUrl { get; set; }
    }
}
