using VideoRentalApp.Models;

namespace VideoRentalApp.Interfaces
{
    public interface IPaymentRepository
    {
        string AddPayment(Payment entity);
        List<Payment> GetAllPayments();
    }
}
