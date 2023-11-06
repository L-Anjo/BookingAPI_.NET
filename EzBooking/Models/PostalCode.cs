namespace EzBooking.Models
{

    public class PostalCode
    {
        public int postalCode;
        public string concelho;
        public string district;
        public ICollection<House> Houses;  
    }


}