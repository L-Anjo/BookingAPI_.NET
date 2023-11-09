using EzBooking.Data;
using EzBooking.Models;

namespace EzBooking.Repository
{
    public class StatusHouseRepo
    {
        private readonly DataContext _context;

        public StatusHouseRepo(DataContext context)
        {
            _context = context;
        }

        public StatusHouse GetStatusHouseById(int id)
        {
            return _context.StatusHouses
                .FirstOrDefault(p => p.id == id);
        }
    }
}
