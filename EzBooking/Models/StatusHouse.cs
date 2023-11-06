namespace EzBooking.Models
{
    public class StatusHouse
    {
        public int id;
        public string name;
        public ICollection<House> Houses;
    }
}