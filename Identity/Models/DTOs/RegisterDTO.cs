namespace Identity.Models.DTOs
{
    public class RegisterDTO
    {
        //bunların hepsi IdentyUser de var ama ben dto oluşturuyorum
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
    }
}
