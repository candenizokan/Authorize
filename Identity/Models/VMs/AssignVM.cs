using System.Collections.Generic;

namespace Identity.Models.VMs
{
    public class AssignVM
    {
        public string RoleName { get; set; }

        public IEnumerable<AppUser> HasRole { get; set; }//role sahip olanlar
        public IEnumerable<AppUser> HasNotRole { get; set; }//role sahip olmayanlar

        public string[] AddIds { get; set; }//role yeni eklenecekler
        public string[] DeleteIds { get; set; }//mevcutta bu rolde olup silinenlerin idleri
    }
}
