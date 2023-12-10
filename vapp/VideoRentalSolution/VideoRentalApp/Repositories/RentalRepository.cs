using Microsoft.EntityFrameworkCore;
using VideoRentalApp.Contexts;
using VideoRentalApp.Interfaces;
using VideoRentalApp.Models;


namespace VideoRentalApp.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        MovieContext _context;
        public RentalRepository(MovieContext context)
        {
            _context = context;
        }
        public string AddRental(Rental rental)
        {
            int count = _context.Rentals.Count();
            _context.Rentals.Add(rental);
            _context.SaveChanges();
            int newcount = _context.Rentals.Count();
            if (newcount > count)
            {
                return "Rental inserted successfully";
            }
            else
            {
                return "oops something went wrong while inserting";
            }
        }

        public string DeleteRental(int id)
        {
            Rental rental = _context.Rentals.Find(id);
            if (rental != null)
            {
                _context.Rentals.Remove(rental);
                _context.SaveChanges();
                return "Rental removed from database";
            }
            else
            {
                return "Rental is not available";
            }

        }
        public List<Rental> GetAllRentals()
        {
            return _context.Rentals.ToList();
        }
        public string UpdateRental(Rental newrental)
        {
            Rental rental = _context.Rentals.FirstOrDefault(d =>
        d.RentalId == newrental.RentalId);
            if (rental != null)
            {
                rental.RentalCost = newrental.RentalCost;

                _context.SaveChanges();
                return "Rental details updated successfully";

            }
            else
            {
                return "Rental details are not updated";
            }

        }
        public Rental GetRentalById(int id)
        {
            Rental rental = _context.Rentals.Find(id);
            return rental;
        }
    }
}