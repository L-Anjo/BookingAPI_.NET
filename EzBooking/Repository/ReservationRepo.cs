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
                .OrderBy(r => r.id_reservation)
                .ToList();

                //FALTA ReservationStatus
        }

        public Reservation GetReservationById(int id)
        {
            return _context.Reservations
                .Include(r => r.House)
                .Include(r => r.User)
                .FirstOrDefault(r => r.id_reservation == id);

                 //FALTA ReservationStatus
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
    }
}
