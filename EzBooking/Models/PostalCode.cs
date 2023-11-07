using System.ComponentModel.DataAnnotations;

namespace EzBooking.Models
{

    public class PostalCode
    {
        [Key]
        public int postalCode { get; set; }
        public string concelho;
        public string district;
        public ICollection<House> Houses;  
    }


}