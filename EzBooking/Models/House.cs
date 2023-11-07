using System.ComponentModel.DataAnnotations;

namespace EzBooking.Models
{
    public class House
    {
        [Key]
        public int id_house { get; set; }
        public string name;
        public int doorNumber;
        public int floorNumber;
        public double price;
        public double priceyear;
        public int guestsNumber;
        public string road;
        public string propertyAssessment;
        public int codDoor;
        public bool sharedRoom;
        public PostalCode PostalCode;
        public StatusHouse StatusHouse;
    }
}