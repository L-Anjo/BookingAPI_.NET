using EzBooking.Data;
using EzBooking.Models;

namespace EzBooking.Repository
{
    public class HouseRepo
    {   
        private readonly DataContext _context;
        public HouseRepo(DataContext context) 
        { 
            _context = context;

        }
        public ICollection<House> GetHouses()
        {
            return _context.Houses.OrderBy(h => h.id_house).ToList();
        }
    }
}
