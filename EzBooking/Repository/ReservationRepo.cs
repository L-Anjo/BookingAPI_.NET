using EzBooking.Data;
using EzBooking.Models;
using Microsoft.EntityFrameworkCore;

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
                return _context.Reservations
                .Include(r => r.House)
                .Include(r => r.User)
                .Include(r => r.ReservationStates)
                .OrderBy(r => r.id_reservation)
                .ToList();
        }

        public Reservation GetReservationById(int id)
        {
            return _context.Reservations
                .Include(r => r.House)
                .Include(r => r.User)
                .Include(r => r.ReservationStates)
                .FirstOrDefault(r => r.id_reservation == id);

        }

        public bool CreateReservation(Reservation reservation)
        {
            _context.Add(reservation);
            return Save();
        }


        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool ReservationExists(int reservationid)
        {
            return _context.Reservations.Any(r => r.id_reservation == reservationid);
        }


        //UPDATE E DELETE MAL
        public bool UpdateReservation(Reservation reservation)
        {

            _context.Update(reservation);
            return Save();
        }

        public bool DeleteReservation(Reservation reservation)
        {
            _context.Remove(reservation);
            return Save();
        }

    }
}
