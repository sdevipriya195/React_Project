using VideoRentalApp.Models;
using VideoRentalApp.Models;

namespace VideoRentalApp.Interfaces
{
    public interface IRentalRepository
    {
        /// <summary>
        /// This is interface for rental class
        /// </summary>
        /// <param name="key">It is ID for rental class</param>
        /// <returns>It provides interface for all crud operations</returns>
        Rental GetRentalById(int key);
        List<Rental> GetAllRentals();
        string AddRental(Rental entity);
        string UpdateRental(Rental entity);
        string DeleteRental(int key);
    }
}