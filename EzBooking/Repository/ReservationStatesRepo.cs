using EzBooking.Data;
using EzBooking.Models;

namespace EzBooking.Repository
{
    public class ReservationStatesRepo
    {
        private readonly DataContext _context;

        public ReservationStatesRepo(DataContext context)
        {
            _context = context;
        }

        public ReservationStates GetReservationStatesById(int id)
        {
            return _context.ReservationStates
                .FirstOrDefault(p => p.id == id);
        }
    }
}