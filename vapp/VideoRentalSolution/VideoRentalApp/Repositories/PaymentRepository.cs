using VideoRentalApp.Contexts;
using VideoRentalApp.Interfaces;
using VideoRentalApp.Models;

namespace VideoRentalApp.Repositories
{
    public class PaymentRepository : IPaymentRepository
        {
            MovieContext _context;
            public PaymentRepository(MovieContext context)
            {
                _context = context;
            }
            public string AddPayment(Payment payment)
            {
                int count = _context.Payments.Count();
                _context.Payments.Add(payment);
                _context.SaveChanges();
                int newcount = _context.Payments.Count();
                if (newcount > count)
                {
                    return "Payment done successfully";
                }
                else
                {
                    return "oops something went wrong during the payment process";
                }
            }
            public List<Payment> GetAllPayments()
            {
                return _context.Payments.ToList();
            }
        }
}
