using EzBooking.Data;
using EzBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace EzBooking.Repository
{
    public class HouseRepo
    {
        private readonly DataContext _context;
        public HouseRepo(DataContext context)
        {
            _context = context;

        }
        public async Task<ICollection<House>> GetHouses()
        {
            return await _context.Houses
                .Include(h => h.PostalCode)
                .Include(h => h.StatusHouse)
                .OrderBy(h => h.id_house)
                .ToListAsync();
        }

        public async Task<House> GetHouseById(int id)
        {
            return await _context.Houses
                .Include(h => h.PostalCode)
                .Include(h => h.StatusHouse)
                .FirstOrDefaultAsync(h => h.id_house == id);
        }

        public ICollection<House> GetHousesSusp()
        {
            return _context.Houses.Where(h => h.StatusHouse.id == 1)
                .Include(h => h.PostalCode)
                .ToList();
        }

        //public decimal GetHouseRating(int id) 
        //{ 
        //    var review = _context
        //}
        //var postalcode = _context.PostalCodes.Where(pc => pc.postalCode == house.PostalCode.postalCode).FirstOrDefault();

        public async Task<bool> CreateHouse(House house)
        { 
            await _context.AddAsync(house);
            return Save();
        }


        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool PostalCodePropertyExists(int postalCode, string propertyAssessment)
        {
            return _context.Houses.Any(h => h.PostalCode.postalCode == postalCode && h.propertyAssessment == propertyAssessment);
        }

        public bool HouseExists(int houseid)
        {
            return _context.Houses.Any(h => h.id_house == houseid);
        }

        public bool UpdateHouse(House house)
        {

            _context.Update(house);
            return Save();
        }

        public bool DeleteHouse(House house)
        {
            _context.Remove(house);
            return Save();
        }
    }
}
