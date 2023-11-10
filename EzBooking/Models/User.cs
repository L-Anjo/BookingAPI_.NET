using System.ComponentModel.DataAnnotations;

namespace EzBooking.Models
{
    public class User
    {
        [Key]
        public int id_user { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string token { get; set; }
        public int status { get; set; }
    }
}