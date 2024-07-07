using System.ComponentModel;

namespace CVAPP.Models
{
    public class User
    {
        public int Id { get; set; }

        [DisplayName("Kullanıcı Adı: ")]
        public string Firstname { get; set; }
        [DisplayName("Kullanıcı Soyadı: ")]
        public string ?Lastname { get; set; }
        [DisplayName("Kullanıcı Mail Adresi: ")]
        public string ?Email { get; set; }
        [DisplayName("Kullanıcı Şifresi: ")]
        public string ?Password { get; set; }
        [DisplayName("Kullanıcı Telefon: ")]
        public string ?PhoneNumber { get; set; }
        [DisplayName("Kullanıcı Adresi: ")]

        public string ?Address { get; set; }

        public ICollection<Cv>Cv { get; set; }
    }
}
