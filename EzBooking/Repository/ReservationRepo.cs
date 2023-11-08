using EzBooking.Data;
using EzBooking.Models;

namespace EzBooking.Repository
{
    public class ReservationRepo
    {   
        private readonly DataContext _context;
        public ReservationRepo(DataContext context) 
        { 
            _context = context;

        }
        public ICollection<Reservation> GetReservations()
        {
            return _context.Reservations.OrderBy(h => h.id_reservation).ToList();
        }
    }
}
