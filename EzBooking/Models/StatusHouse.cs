using System.ComponentModel.DataAnnotations;

namespace EzBooking.Models
{
    public class StatusHouse
    {
        [Key]
        public int id { get; set; }
        public string name;
        public ICollection<House> Houses;
    }
}