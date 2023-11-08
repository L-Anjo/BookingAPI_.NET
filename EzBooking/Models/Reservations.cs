using System.ComponentModel.DataAnnotations;

namespace EzBooking.Models
{
    public class Reservation
    {
        [Key]
        public int id_reservation { get; set; }
        // DATE? public string init_date { get; set; }
        // DATE? public int end_date { get; set; }
        // public User User { get; set; }
        public House House { get; set; }
        // public ReservationSate ReservationSate { get; set; }
        // public Payment Payment { get; set; }
    }
}