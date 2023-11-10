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
        public ICollection<House> GetHouses()
        {
            return _context.Houses
                .Include(h => h.PostalCode)
                .Include(h => h.StatusHouse)
                .OrderBy(h => h.id_house)
                .ToList();
        }

        public House GetHouseById(int id)
        {
            return _context.Houses
                .Include(h => h.PostalCode)
                .Include(h => h.StatusHouse)
                .FirstOrDefault(h => h.id_house == id);
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

        public bool CreateHouse(House house)
        {
            _context.Add(house);
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
    }
}
