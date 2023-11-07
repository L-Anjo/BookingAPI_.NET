using System.ComponentModel.DataAnnotations;

namespace EzBooking.Models
{
    public class House
    {
        [Key]
        public int id_house { get; set; }
        public string name { get; set; }
        public int doorNumber { get; set; }
        public int floorNumber { get; set; }
        public double? price { get; set; }
        public double? priceyear { get; set; }
        public int guestsNumber { get; set; }
        public string road { get; set; }
        public string propertyAssessment { get; set; }
        public int? codDoor { get; set; }
        public bool sharedRoom { get; set; }
        public PostalCode PostalCode { get; set; }
        public StatusHouse StatusHouse { get; set; }
    }
}