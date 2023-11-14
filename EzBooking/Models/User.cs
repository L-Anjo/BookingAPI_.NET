using System.ComponentModel.DataAnnotations;

namespace EzBooking.Models
{
    public class User
    {
        [Key]
        public int id_user { get; set; }
        [Required(ErrorMessage = "O campo Nome � obrigat�rio.")]
        public string name { get; set; }
        [Required(ErrorMessage = "O campo Email � obrigat�rio.")]
        public string email { get; set; }
        [Required(ErrorMessage = "O campo Password � obrigat�rio.")]
        public string password { get; set; }
        [Required(ErrorMessage = "O campo Phone � obrigat�rio.")]
        public string phone { get; set; }
        public string? token { get; set; }
        public int? status { get; set; }
    }
}