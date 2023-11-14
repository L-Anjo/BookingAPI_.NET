using System.ComponentModel.DataAnnotations;

namespace EzBooking.Models
{
    public class User
    {
        [Key]
        public int id_user { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string name { get; set; }
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        public string email { get; set; }
        [Required(ErrorMessage = "O campo Password é obrigatório.")]
        public string password { get; set; }
        [Required(ErrorMessage = "O campo Phone é obrigatório.")]
        public string phone { get; set; }
        public string? token { get; set; }
        public int? status { get; set; }
    }
}