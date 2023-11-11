using EzBooking.Data;
using EzBooking.Models;

namespace EzBooking.Repository
{
    public class PaymentRepo
    {
        private readonly DataContext _context;
        public PaymentRepo(DataContext context)
        {
            _context = context;

        }
        public ICollection<Payment> GetPayments()
        {
            return _context.Payments.OrderBy(h => h.id_payment).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool CreatePayment(Payment payment)
        {
            _context.Add(payment);
            return Save();
        }

        public Payment GetPayment(int paymentId)
        {
            return _context.Payments.Where(p => p.id_payment == paymentId).FirstOrDefault();
        }


    }
}
