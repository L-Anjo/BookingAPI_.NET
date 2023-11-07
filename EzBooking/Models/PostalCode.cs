using System.ComponentModel.DataAnnotations;

namespace EzBooking.Models
{

    public class PostalCode
    {
        [Key]
        public int postalCode { get; set; }
        public string concelho { get; set; }
        public string district { get; set; }
        public ICollection<House> Houses { get; set; }
    }


}