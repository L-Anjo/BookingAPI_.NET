using EzBooking.Data;
using EzBooking.Models;

namespace EzBooking.Repository
{
    public class PaymentStateRepo
    {
        private readonly DataContext _context;
        public PaymentStateRepo(DataContext context)
        {
            _context = context;
        }

        public ICollection<PaymentStates> GetPaymentStates()
        {
            return _context.PaymentStates.OrderBy(h => h.id_paymentStates).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool CreatePaymentStates(PaymentStates paymentStates)
        {
            _context.Add(paymentStates);
            return Save();
        }

        public PaymentStates GetPaymentStates(int paymentStates)
        {
            return _context.PaymentStates.Where(p => p.id_paymentStates == paymentStates).FirstOrDefault();
        }


        public bool DeletePaymentStates(PaymentStates paymentStates)
        {
            _context.Remove(paymentStates);
            return Save();
        }

    }
}
