using System.ComponentModel.DataAnnotations;

namespace EzBooking.Models
{
    public class Reservation
    {
        [Key]
        public int id_reservation { get; set; }
        public DateTime init_date { get; set; }
        public DateTime end_date { get; set; }
        public User User { get; set; }
        public House House { get; set; }
        public ReservationStates? ReservationStates { get; set; }

        // public Payment Payment { get; set; }
    }
}